using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.ViewModels.Templates;

namespace Jaguar.Desktop.CustomViews.Templates;

public partial class AgentTemplatesView : UserControl
{
    public AgentTemplatesView()
    {
        InitializeComponent();
        DataContext = new AgentTemplatesViewModel();
    }
    
   private async void OnTemplatePointerPressed(object? sender, PointerPressedEventArgs e)
   {
       // 1. 'sender' is the Border that was clicked
       if (sender is Border border && border.DataContext is FlowNode template)
       {
           // 2. Prepare the data
           var dragData = new DataObject();
           dragData.Set("AgentTemplate", template);
   
           // 3. Start the drag operation
           // On Zorin OS/Linux, using 'Copy' effect is standard for "dragging out"
           await DragDrop.DoDragDrop(e, dragData, DragDropEffects.Copy);
       }
   }
}