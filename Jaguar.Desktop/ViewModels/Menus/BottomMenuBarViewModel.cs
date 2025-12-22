using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.Services.AppState;
using Microsoft.Extensions.DependencyInjection;

namespace Jaguar.Desktop.ViewModels.Menus
{
    public partial class  BottomBarMenuViewModel: ViewModelBase
    {
        [ObservableProperty] private AppStateService? _appState;
         public ObservableCollection<MenuItems> MenuItems {get; set;}
        
         public BottomBarMenuViewModel()
         {
             if (Program.AppHost != null)
             {
                 AppState = Program.AppHost.Services.GetRequiredService<AppStateService>();
             }
             MenuItems = new ObservableCollection<MenuItems>(new List<MenuItems>
             {
                 // new MenuItems("Ready", "Ready", "Bottom"),
                 // new MenuItems("Jaguar.Api: Connected", "Status", "Bottom"),
                 // new MenuItems("LLM: Ollama (Llama 3)", "Status", "Bottom"),
                 // new MenuItems("CPU: 12%", "Status", "Bottom"),
                 // new MenuItems("Memory: 1.2GB",  "Status", "Bottom"),
                 // new MenuItems("UTF-8", "None", "Bottom"),
                 // new MenuItems("Ln 1, Col 1", "None", "Bottom"),
                 // new MenuItems("Main-Branch", "Git", "Bottom")
             });
         }
    }
}