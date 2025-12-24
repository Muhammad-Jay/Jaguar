using System;
using Jaguar.Desktop.Models.Ui;
using Material.Icons;

namespace Jaguar.Desktop.Models
{
    public record MenuItems(string Name, MaterialIconKind Icon, Type ViewModel, Position Position);
}