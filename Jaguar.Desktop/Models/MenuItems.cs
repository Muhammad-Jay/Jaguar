using System;

namespace Jaguar.Desktop.Models
{
    public enum Position
    {
        Right,
        Left,
        Top,
        Bottom
    }
    public record MenuItems(string name, string action, string position);
}