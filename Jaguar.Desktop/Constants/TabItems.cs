using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Jaguar.Desktop.CustomViews.MenuItemView;
using Jaguar.Desktop.CustomViews.Templates;
using Jaguar.Desktop.Models;
using Jaguar.Desktop.Models.Ui;
using Material.Icons;

namespace Jaguar.Desktop.Constants;

public partial class TabItemsList: ObservableObject
{
    public static ObservableCollection<MenuItems> ItemList = new ObservableCollection<MenuItems>()
    {
        new MenuItems("Properties", MaterialIconKind.Settings, typeof(AgentTemplatesView), Position.Right),
        new MenuItems("Inspector", MaterialIconKind.Eye, typeof(SettingsView), Position.Right),
        new MenuItems("Agents", MaterialIconKind.CardSearch, typeof(AgentTemplatesView), Position.Right),
        new MenuItems("History", MaterialIconKind.History, typeof(AgentTemplatesView), Position.Right)
    };
}