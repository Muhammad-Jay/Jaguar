using System;
using System.Collections.ObjectModel;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Core.Models;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.Models.Ui;
using Jaguar.Desktop.Services.AppState;
using Material.Icons;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.ViewModels;

public partial class ProjectsViewModel: ViewModelBase
{
    private readonly IServiceProvider _serviceProvider;
    [ObservableProperty] private AppStateService _appState;
    [ObservableProperty] private ViewModelBase? _graphContent;

    [ObservableProperty] private ToolPanelViewModel? _leftTools;
    [ObservableProperty] private ToolPanelViewModel? _rightTools;
    [ObservableProperty] private ToolPanelViewModel? _topTools;
    [ObservableProperty] private SpotlightViewModel? _spotlight;

    public ObservableCollection<WorkflowTemplate> Templates { get; } = new();
    [ObservableProperty] private WorkflowTemplate? _selectedTemplate;

    
    [ObservableProperty] private bool _isCreateProjectLoading;
    

    [ObservableProperty] private string _name = string.Empty;
    public ProjectsViewModel(IServiceProvider serviceProvider, AppStateService appStateService)
    {
        Console.WriteLine("--> Attempting to load projects screen...");
        _serviceProvider = serviceProvider;
        AppState = appStateService;
        AppState.IsCreateProjectDialogOpen = false;
        InitializeTemplates();
        InitializeToolItems();
        GraphContent = serviceProvider.GetRequiredService<CanvasViewModel>();
        Spotlight = new SpotlightViewModel();
        Spotlight.LoadSlides();
        Spotlight.StartRotation();
        Console.WriteLine("--> Projects loaded.");
    }

    private void InitializeTemplates()
    {
        Templates.Clear();
        
        Templates.Add(new WorkflowTemplate
        {
            Title = "Blank Project",
            Description = "Start with an empty graph",
            Type = WorkflowTemplateType.BlankTemplate
        });
        Templates.Add(new WorkflowTemplate
        {
            Title = "Node System",
            Description = "Logic-driven node graph",
            Type = WorkflowTemplateType.NodeSystem
        });Templates.Add(new WorkflowTemplate
        {
            Title = "State Machine",
            Description = "Event-based flow and transition",
            Type = WorkflowTemplateType.StateMachine
        });Templates.Add(new WorkflowTemplate
        {
            Title = "Data Pipeline",
            Description = "Transform and process data",
            Type = WorkflowTemplateType.DataPipeline
        });Templates.Add(new WorkflowTemplate
        {
            Title = "From Template",
            Description = "Choose from predefined setups",
            Type = WorkflowTemplateType.FromTemplate
        });
    }

    private void InitializeToolItems()
    {
        LeftTools = new ToolPanelViewModel
        {
            Title = "Projects",
            Orientation = Orientation.Vertical,
            Items = CreateLeftTools(),
            Size = new Size(30, 100)
        };
        RightTools = new ToolPanelViewModel
        {
            Title = "Projects",
            Orientation = Orientation.Vertical,
            Items = CreateRightTools(),
            Size = new Size(30, 100)
            
        };
        TopTools = new ToolPanelViewModel
        {
            Title = "Projects",
            Orientation = Orientation.Horizontal,
            Items = CreateTopTools(),
            Size = new Size(100, 30)
        };
    }

    private ObservableCollection<ToolMenuItem> CreateLeftTools()
    {
        return new ObservableCollection<ToolMenuItem>
        {
            new ToolMenuItem { Text = "Projects", Size = new Size(25, 25), IsVertical = true, IconKind = MaterialIconKind.FolderOpen},
            new ToolMenuItem { Text = "Agents" , Size = new Size(25, 25), IsVertical = true, IconKind = MaterialIconKind.Psychology},
            new ToolMenuItem { Text = "Models" , Size = new Size(25, 25), IsVertical = true, IconKind = MaterialIconKind.Memory},
            new ToolMenuItem { Text = "Data Storage" , Size = new Size(25, 25), IsVertical = true, IconKind = MaterialIconKind.Storage},
            new ToolMenuItem { Text = "Dependencies", Size = new Size(25, 25), IsVertical = true, IconKind = MaterialIconKind.Dependencies},
        };
    }
    
    private ObservableCollection<ToolMenuItem> CreateRightTools()
    {
        return new ObservableCollection<ToolMenuItem>
        {
            new ToolMenuItem { Text = "Selection Details", Size = new Size(25, 25), IsVertical = true,  IconKind = MaterialIconKind.Info},
            new ToolMenuItem { Text = "Memory View" , Size = new Size(25, 25), IsVertical = true,  IconKind = MaterialIconKind.Dns},
            new ToolMenuItem { Text = "Logs", Size = new Size(25, 25), IsVertical = true,  IconKind = MaterialIconKind.Terminal},
            new ToolMenuItem { Text = "Notes", Size = new Size(25, 25), IsVertical = true,  IconKind = MaterialIconKind.NoteAdd},
        };
    }
    
    private ObservableCollection<ToolMenuItem> CreateTopTools()
    {
        return new ObservableCollection<ToolMenuItem>
        {
            new ToolMenuItem { Text = "Templates" , Size = new Size(25, 25),  IsVertical = false,IconKind = MaterialIconKind.Collections},
            new ToolMenuItem { Text = "Tools", Size = new Size(25, 25), IsVertical = false, IconKind = MaterialIconKind.Build},
            // new ToolMenuItem { Text = "Models", Size = new Size(25, 25), IsVertical = false, IconKind = MaterialIconKind.Memory},
            new ToolMenuItem { Text = "Artifacts", Size = new Size(25, 25), IsVertical = false, IconKind = MaterialIconKind.Collection},
            new ToolMenuItem { Text = "Version History", Size = new Size(25, 25), IsVertical = false, IconKind = MaterialIconKind.History},
            new ToolMenuItem { Text = "Settings" , Size = new Size(25, 25), IsVertical = false, IconKind = MaterialIconKind.Settings},
            new ToolMenuItem { Text = "Run Simulation" , Size = new Size(25, 25), IsVertical = false, IconKind = MaterialIconKind.PlayArrow},
            new ToolMenuItem { Text = "Pause", Size = new Size(25, 25), IsVertical = false, IconKind = MaterialIconKind.Pause},
            new ToolMenuItem { Text = "Stop", Size = new Size(25, 25), IsVertical = false, IconKind = MaterialIconKind.Stop},
            // new ToolMenuItem { Text = "Validate Graph", Size = new Size(25, 25), IsVertical = false, IconKind = MaterialIconKind.Flowchart},
            new ToolMenuItem { Text = "Inspect State", Size = new Size(25, 25), IsVertical = false, IconKind = MaterialIconKind.Visibility},
            // new ToolMenuItem { Text = "Export Results" , Size = new Size(25, 25), IsVertical = false, IconKind = MaterialIconKind.FileDownload},
        };
    }

    [RelayCommand]
    public void ProjectClicked(Project project)
    {
        AppState.CurrentProject = project;
        AppState.SetView(AppScreen.ProjectDashboard);
    }

    [RelayCommand]
    public void SetView() => AppState.SetView(AppScreen.Workflow);

    [RelayCommand]
    public void CloseDialog() => AppState.IsCreateProjectDialogOpen = false;
    
    
    [RelayCommand]
    public void ToggleDialog() => AppState.IsCreateProjectDialogOpen = !AppState.IsCreateProjectDialogOpen;

    [RelayCommand]
    public void CreateNewProject()
    {
        if (string.IsNullOrWhiteSpace(Name))
            return;
        
        IsCreateProjectLoading = true;
        AppState.CreateProject(Name);
        Console.WriteLine($"--> Project created sucessfully.");
        IsCreateProjectLoading = false;
        AppState.SetView(AppScreen.ProjectDashboard);
    }

    [RelayCommand]
    public void TemplateSelected(WorkflowTemplate template)
    {
        SelectedTemplate = template;
        foreach (var t in Templates)
        {
            if (t.Type == template.Type)
            {
                t.IsSelected = true;
            }
            else
            {
                t.IsSelected = false;
            }
        }
    }
}