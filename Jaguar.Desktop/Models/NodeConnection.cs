using CommunityToolkit.Mvvm.ComponentModel;
using Jaguar.Desktop.Views;

namespace Jaguar.Desktop.Models;

public partial class ConnectionViewModel : ObservableObject
{
    [ObservableProperty]
    private ConnectorViewModel? _source;
       
    [ObservableProperty]
    private ConnectorViewModel? _target;
}