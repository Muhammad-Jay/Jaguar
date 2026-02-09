using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Core.Abstractions;
using Jaguar.Core.Events;
using Jaguar.Core.Models;
using Jaguar.Core.Models.Graph;
using Jaguar.Desktop.Abstractions;
using Jaguar.Desktop.CustomViews.Templates;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.Models.Ui;
using Jaguar.Desktop.Services.Events.Ui;
using Jaguar.Desktop.ViewModels;
using Jaguar.Desktop.ViewModels.Dialog.Contents;
using Jaguar.Desktop.ViewModels.Templates;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.Services.AppState
{
    public partial class AppStateService: ObservableObject, IAppStateService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IEventAggregator _events;
        private readonly IProjectService _projectService;

        public ObservableCollection<Project> Projects { get; set; } = new();
        public ObservableCollection<FlowNode> CurrentProjectNodes { get; set; } = new();
        [ObservableProperty] private Project? _currentProject;
        
        [ObservableProperty] private object? _currentScreen;
        [ObservableProperty] private AppScreen _currentScreenType;
        
        [ObservableProperty] private object? _currentView;
        [ObservableProperty] private object? _currentDialogView;
        [ObservableProperty] private PanelRequest? _activePanel;
        [ObservableProperty] private bool _isRightPanelOpen = true;
        [ObservableProperty] private bool _isLeftPanelOpen = false;
        [ObservableProperty] private bool _isTopPanelOpen = false;
        
        // Loading states
        [ObservableProperty] private bool _isProjectsLoading = false;

        // Workflow Dialogs States
        private readonly double _defaultDialogWidth = 300;
        private readonly double _defaultDialogHeight = 400;
        
        [ObservableProperty] private bool _isAgentDialogOpen;
        [ObservableProperty] private bool _isCreateProjectDialogOpen;
        [ObservableProperty] private double _dialogWidth;
        [ObservableProperty] private double _dialogHeight;
        
        public AppStateService(IServiceProvider serviceProvider, IEventAggregator eventAggregator, IProjectService projectService)
        {
            _serviceProvider = serviceProvider;
            _events = eventAggregator;
            _projectService = projectService;
            
            Projects.Clear();
            
            InitializeServices();
            SubscribeToEvents();
        }
        
        private void InitializeServices()
        {
            try
            {
                if (Program.AppHost != null)
                {
                    CurrentScreen = new SplashScreenViewModel(_serviceProvider, this);
                    CurrentScreenType = AppScreen.SplashScreen;
                    
                    CurrentView = _serviceProvider.GetRequiredService<AgentTemplatesViewModel>();
                    CurrentDialogView = new OrchestratorDialogPromptViewModel(this, _events);
                    ActivePanel = new PanelRequest { ViewModel = CurrentView, Position = Position.Left};
                    IsRightPanelOpen = false;
                    IsLeftPanelOpen = true;
                    IsTopPanelOpen = false;
                    IsAgentDialogOpen = false;
                    DialogWidth = _defaultDialogWidth;
                    DialogHeight = _defaultDialogHeight;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Service Init Error: {ex.Message}");
            }
        }
        
        private void SubscribeToEvents()
        {
            _events.Subscribe<OpenAgentTemplateDialogEvent>(_ => OpenOrchestratorDialog());

            _events.Subscribe<CloseDialogEvent>(_ =>
            {
                CurrentDialogView = null;
                IsAgentDialogOpen = false;
                DialogWidth = _defaultDialogWidth;
                DialogHeight = _defaultDialogHeight;
            });

            _events.Subscribe<OpenPanelEvent>(e =>
            {
                RequestPanel(e.ViewModel, e.Position, e.Size);
            });
        }

        private void SeedProjects()
        {
            var pro1 = _projectService.CreateProject("NewProject12");
            var pro2 = _projectService.CreateProject("JaguarNewProject2");
            var pro3 = _projectService.CreateProject("NewJaguar3");
        }

        public void LoadAllProjects()
        {
            // SeedProjects();
            if(_projectService == null) return;
            
            Projects.Clear();
            
            foreach (var p in _projectService.GetAllProjects())
            {
                Console.WriteLine($"--> Project: {p.Id} - {p.Name} loaded.  [{p.Path}]");

                Projects.Add(p);
            }
            
            LoadProjectNodes(Projects[0].Name);
        }

        public void CreateProject(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return;

            Console.WriteLine($"Creating Prokect: {name}");
            var project = _projectService.CreateProject(name);
            CurrentProject = project;
            Projects.Add(project);
        }

        public void LoadProjectNodes(string projectNane)
        {
            var nodes = _projectService.GetProjectNodes(projectNane);

            if (nodes.Any())
            {
                foreach (var node in nodes)
                {
                    CurrentProjectNodes.Add(node);
                }
            }
        }
        
        public void SetView(AppScreen screen)
        {
            switch (screen)
            {
                case AppScreen.SplashScreen:
                   CurrentScreen = new SplashScreenViewModel(_serviceProvider, this);
                    break;
                case AppScreen.Projects:
                    CurrentScreen = new ProjectsViewModel(_serviceProvider, this);
                    break;
                case AppScreen.ProjectDashboard:
                    // CurrentScreen = new ProjectDashboardViewModel(_serviceProvider, this);
                    CurrentScreen = _serviceProvider.GetRequiredService<WorkflowViewModel>();
                    break;
                case AppScreen.Workflow:
                    CurrentScreen = new WorkflowViewModel(_serviceProvider, this);
                    break;
                default:
                    CurrentScreen = new ProjectsViewModel(_serviceProvider, this);
                    break;
            }

            CurrentScreenType = screen;
        }
        
        public void RequestPanel(object vm, Position pos, double? size = 350)
        {
            if (ActivePanel?.ViewModel == vm)
            {
                switch (pos)
                {
                    case Position.Right:
                        IsRightPanelOpen = false;
                        ActivePanel = null;
                        break;
                    default:
                        return;
                        break;
                }
            }
            else
            {
                ActivePanel = new PanelRequest { ViewModel = vm, Position = pos, Size = size };
                IsRightPanelOpen = true;
            }
        }

        public void OpenOrchestratorDialog()
        {
            DialogWidth = 900;
            DialogHeight = 700;
            CurrentDialogView = _serviceProvider.GetRequiredService<OrchestratorDialogPromptViewModel>();
            IsAgentDialogOpen = true;
        }
   
        public void ClosePanel () =>  IsRightPanelOpen = false;
        
        [RelayCommand]
        public void TogglePanel () =>  IsRightPanelOpen = !IsRightPanelOpen;

        public void RunTask(string task)
        {
            _events.Publish(new TaskCreatedEvent(task, Guid.NewGuid()));
        }
    }
}
