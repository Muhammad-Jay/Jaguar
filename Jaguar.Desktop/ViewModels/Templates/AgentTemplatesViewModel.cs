using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Desktop.Constants.Nodes;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.Models.Templates;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.ViewModels.Templates;

public partial class AgentTemplatesViewModel : ViewModelBase
{
    public ObservableCollection<FlowNode> AvailableTemplates { get; }
    
    private readonly IServiceProvider _serviceProvider;
    
    public AgentTemplatesViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        
        // Initialize templates from your static helper
        AvailableTemplates = new ObservableCollection<FlowNode>(NodeCatalog.DefaultAgentTemplates);
        Console.WriteLine(AvailableTemplates.Count);
    }

    [RelayCommand]
    public void OnItemClick(FlowNode item)
    {
        var canvasVm = _serviceProvider.GetRequiredService<CanvasViewModel>();
        
        Console.WriteLine($"{item.Type} Node Added. Count: {canvasVm.Nodes.Count}");
        canvasVm.AddNodeAtLocation(item);
    }
}