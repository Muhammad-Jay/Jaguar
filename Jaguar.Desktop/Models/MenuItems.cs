using System;
using Jaguar.Desktop.Models.Ui;
using Material.Icons;

namespace Jaguar.Desktop.Models
{
    public record MenuItems(string Name, MaterialIconKind Icon, object ViewModel, Position Position);
}