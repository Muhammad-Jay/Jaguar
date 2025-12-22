using System;
using Jaguar.Desktop.Models.Ui;

namespace Jaguar.Desktop.Models
{
    public record MenuItems(string name, Type viewModel, Position Position);
}