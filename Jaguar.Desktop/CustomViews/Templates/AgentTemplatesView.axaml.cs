using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.ViewModels;
using Jaguar.Desktop.ViewModels.Templates;

namespace Jaguar.Desktop.CustomViews.Templates;

public partial class AgentTemplatesView : UserControl
{
    public AgentTemplatesView()
    {
        InitializeComponent();
        DataContext = new AgentTemplatesViewModel();
    }
}