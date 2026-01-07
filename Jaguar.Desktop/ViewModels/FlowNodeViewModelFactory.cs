using Jaguar.Core.Abstractions;
using Jaguar.Core.Models.Graph;

namespace Jaguar.Desktop.ViewModels;

public partial class FlowNodeViewModelFactory : ViewModelBase
{
    private readonly IEventAggregator _event;

    public FlowNodeViewModelFactory(IEventAggregator eventAggregator)
    {
        _event = eventAggregator;
    }

    public FlowNodeViewModel CreateNode(FlowNode newNode)
    {
        return new FlowNodeViewModel(newNode, _event);
    }
}