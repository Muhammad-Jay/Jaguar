using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Jaguar.Desktop.ViewModels.Dialog.Contents;

public partial class OrchestratorDialogPromptViewModel : ViewModelBase
{

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Stats))]
    private string _prompt = string.Empty;
    
    public string Stats => $"{Prompt?.Length ?? 0} chars | ~{(Prompt?.Length ?? 0) / 4} tokens";
    public OrchestratorDialogPromptViewModel()
    {
        
    }
    
    [RelayCommand]
    public void ExecuteRequest()
    {
        Console.WriteLine($"Request: {Prompt}");
    }
}