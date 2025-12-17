using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Jaguar.Desktop.Models;

namespace Jaguar.Desktop.ViewModels.Menus
{
    public partial class  BottomBarMenuViewModel: ViewModelBase
    {
         public ObservableCollection<MenuItems> MenuItems {get; set;}
        
         public BottomBarMenuViewModel()
         {
             MenuItems = new ObservableCollection<MenuItems>(new List<MenuItems>
             {
                 new MenuItems("Ready"),
                 new MenuItems("Jaguar.Api: Connected"),
                 new MenuItems("LLM: Ollama (Llama 3)"),
                 new MenuItems("CPU: 12%"),
                 new MenuItems("Memory: 1.2GB"),
                 new MenuItems("UTF-8"),
                 new MenuItems("Ln 1, Col 1"),
                 new MenuItems("Main-Branch")
             });
         }
    }
}