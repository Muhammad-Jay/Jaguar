using ReactiveUI; 
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Jaguar.Desktop.ViewModels
{
    // The Base class for all ViewModels in your desktop project
    public class ViewModelBase : ReactiveObject 
    {
        // Note: If your project didn't include ReactiveUI, this class would 
        // typically implement INotifyPropertyChanged manually. 
        // ReactiveObject handles this for you, which is ideal.
    }
}