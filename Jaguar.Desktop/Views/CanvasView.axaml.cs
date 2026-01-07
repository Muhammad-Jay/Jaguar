using System;
using Avalonia.Controls;

namespace Jaguar.Desktop.Views
{
    public partial class CanvasView : UserControl
    {
        public CanvasView()
        {
            InitializeComponent();
            Console.WriteLine("CanvasView loaded");
        }
    }
}