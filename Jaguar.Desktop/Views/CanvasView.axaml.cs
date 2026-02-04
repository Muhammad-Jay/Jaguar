using System;
using System.Collections.Specialized;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.PanAndZoom;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.VisualTree;
using Jaguar.Desktop.ViewModels;
using Material.Icons;

namespace Jaguar.Desktop.Views
{
    public partial class CanvasView : UserControl
    {
        private ZoomBorder? _zoomHost;
        private CanvasViewModel? ViewModel => DataContext as CanvasViewModel;
        public CanvasView()
        {
            InitializeComponent();

            this.DataContextChanged += OnDataContextChanged;

            _zoomHost = this.Find<ZoomBorder>("ZoomHost");
            
            if (_zoomHost != null)
            {
                _zoomHost.EnableAnimations = true;
                _zoomHost.AnimationDuration = TimeSpan.FromMilliseconds(300);
                _zoomHost.EnableDoubleClickZoom = true;
                _zoomHost.DoubleClickZoomMode = DoubleClickZoomMode.ZoomIn;
                _zoomHost.DoubleClickZoomFactor = 2.0;
                
                _zoomHost.ShowGrid = true;
                _zoomHost.GridSize = 50.0; // Grid spacing in content coordinates
                _zoomHost.GridBrush = Brushes.DimGray;
                _zoomHost.GridThickness = 1.0;
                _zoomHost.GridOpacity = 0.3;
                
                _zoomHost.EnableKeyboardNavigation = true;
                _zoomHost.KeyboardPanStep = 50.0;
                _zoomHost.KeyboardZoomStep = 1.1;
                
                _zoomHost.WheelWithCtrl = WheelBehaviorMode.PanVertical;
                _zoomHost.WheelWithShift = WheelBehaviorMode.PanHorizontal;
                
                _zoomHost.KeyDown += ZoomBorder_KeyDown;
                _zoomHost.ZoomChanged += ZoomBorder_ZoomChanged;
               
            }
            Console.WriteLine("CanvasView loaded");
        }
        
        private void ZoomBorder_KeyDown(object? sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F:
                    _zoomHost?.Fill();
                    break;
                case Key.U:
                    _zoomHost?.Uniform();
                    break;
                case Key.R:
                    _zoomHost?.ResetMatrix();
                    break;
                case Key.T:
                    _zoomHost?.ToggleStretchMode();
                    _zoomHost?.AutoFit();
                    break;
            }
        }

        private void ZoomBorder_ZoomChanged(object sender, ZoomChangedEventArgs e)
        {
           UpdateOverlayPosition();
        }

        private void OnDataContextChanged(object? sender, EventArgs e)
        {
            if (ViewModel != null)
            {
                ViewModel.SelectedNodes.CollectionChanged += (_, _) =>
                {
                    ViewModel.SyncOverlays();
                    UpdateOverlayPosition();
                };
            }
        }
        
        private void UpdateOverlayPosition()
        {
            if (ViewModel != null)
            {
                foreach (var overlay in ViewModel.NodeOverlays)
                {
                    var node = overlay.Node;

                    var worldPoint = new Point(
                        node.Location.X + node.Size.Width / 2,
                        node.Location.Y
                    );

                    overlay.ScreenPosition = _zoomHost!.ContentToViewport(worldPoint);
                }
            }
        }
    }
}