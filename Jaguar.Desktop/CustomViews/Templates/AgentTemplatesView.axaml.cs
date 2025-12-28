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
    
    private async void OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (sender is Control control && control.DataContext is AgentTemplatesViewModel selected)
        {
            // var data = new DataObject();
            // // Custom key to identify Jaguar agents
            // data.Set("JaguarNode", selected);
            //
            // // Start the async drag operation
            // await DragDrop.DoDragDropAsync(e, data, DragDropEffects.Copy);
        }
    }
}