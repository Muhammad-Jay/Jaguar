using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.Models.Templates;

namespace Jaguar.Desktop.ViewModels.Templates;

public partial class AgentTemplatesViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<FlowNode> _availableTemplates;

    public AgentTemplatesViewModel()
    {
        _availableTemplates = new ObservableCollection<FlowNode>(AgentTemplates.GetAvailableAgents());
    }
    
}