using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Core.Models;
using Jaguar.Core.Services;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.Services.AppState;
using Jaguar.Desktop.ViewModels.Dialog;
using Jaguar.Desktop.ViewModels.Menus;
using Jaguar.Desktop.ViewModels.Panel;
using Jaguar.Desktop.ViewModels.Templates;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.ViewModels
{
    public partial class WorkflowViewModel : ViewModelBase
    {
        [ObservableProperty] private string _layoutPath =
            "M0 20C0 8.95431 8.95431 0 20 0H360.716C366.02 0 371.107 2.10714 374.858 5.85786L381.142 12.1421C384.893 15.8929 389.98 18 395.284 18H878.216C883.52 18 888.607 15.8929 892.358 12.1421L898.642 5.85786C902.393 2.10713 907.48 0 912.784 0H1252C1263.05 0 1272 8.9543 1272 20V180.817V353V686C1272 697.046 1263.05 706 1252 706H20C8.95433 706 0 697.046 0 686V504.285C0 497.936 3.6616 492.156 9.40232 489.443C15.143 486.73 18.8046 480.95 18.8046 474.601V226.402C18.8046 220.162 15.8926 214.28 10.9306 210.497L7.87407 208.166C2.91209 204.383 0 198.501 0 192.262V20Z";
        
        [ObservableProperty] private Orchestrator? _workFlowOrchestrator;
        [ObservableProperty] private AppStateService? _appState;
        [ObservableProperty] private ViewModelBase? _content;
        [ObservableProperty] private OrchestratorAnalysis? _analysis;
        [ObservableProperty] private bool _isOverlayVisible;
        
        [ObservableProperty] private DialogViewModel _dialogVm;
        [ObservableProperty] private WorkflowSidebarPanelViewModel _workflowSidebarVm;
        [ObservableProperty] private RightBarMenuViewModel _rightBarMenuVm;
        [ObservableProperty] private LeftBarMenuViewModel _leftBarMenuVm;
        
        public WorkflowViewModel(Orchestrator orchestrator, CanvasViewModel canvas, IServiceProvider serviceProvider)
        {
            AppState = serviceProvider.GetRequiredService<AppStateService>();
            DialogVm = serviceProvider.GetRequiredService<DialogViewModel>();
            WorkflowSidebarVm = serviceProvider.GetRequiredService<WorkflowSidebarPanelViewModel>();
            RightBarMenuVm = serviceProvider.GetRequiredService<RightBarMenuViewModel>();
            LeftBarMenuVm = serviceProvider.GetRequiredService<LeftBarMenuViewModel>();
            _workFlowOrchestrator = orchestrator;
            Content = canvas;
        }
        
        [RelayCommand] 
        public void ToggleOverlay()
        {
            IsOverlayVisible = !IsOverlayVisible;
        }
        
        [RelayCommand]
        public void ToggleRightPanel () =>  AppState.IsRightPanelOpen = !AppState.IsRightPanelOpen;
        
        [RelayCommand]
        public void ToggleLeftPanel () =>  AppState.IsLeftPanelOpen = !AppState.IsLeftPanelOpen;
        
        
        
        // [RelayCommand]
        // public async Task RunTestCommand()
        // {
        //     Console.WriteLine("Running Test Command...");
        //     string testPrompt = "Design a small console app that logs Zorin OS system temperatures.";
        //     
        //     Analysis = await WorkFlowOrchestrator.InitializeProjectAsync(testPrompt);
        // }
    }
}