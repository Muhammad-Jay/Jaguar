using System;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.Models.Templates;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.ViewModels.Templates;

public partial class AgentTemplatesViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<FlowNode> _availableTemplates;

    private CanvasViewModel? _canvasVm;

    public AgentTemplatesViewModel()
    {
        _availableTemplates = new ObservableCollection<FlowNode>(AgentTemplates.GetAvailableAgents());
        if (Program.AppHost != null)
        {
            _canvasVm = Program.AppHost.Services.GetRequiredService<CanvasViewModel>();
        }
    }

    [RelayCommand]
    public void OnItemClick(FlowNode item)
    {
        if(_canvasVm == null) return;
        Console.WriteLine(item.Type);
        _canvasVm.AddNode(item);
    }
}