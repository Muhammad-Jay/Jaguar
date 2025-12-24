using CommunityToolkit.Mvvm.ComponentModel;
using Jaguar.Desktop.ViewModels.Templates;

namespace Jaguar.Desktop.ViewModels.Panel;

public partial class  WorkflowSidebarPanelViewModel: ViewModelBase
{
    [ObservableProperty] private ViewModelBase _content;
    
    public WorkflowSidebarPanelViewModel()
    {
        Content = new AgentTemplatesViewModel();
    }

    public void SetContent(ViewModelBase content)
    {
        Content = content;
    }
}