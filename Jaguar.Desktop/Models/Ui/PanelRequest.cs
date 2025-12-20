namespace Jaguar.Desktop.Models.Ui;

public enum Position
{
    Left,
    Right,
    Top,
    Bottom
};

public record PanelRequest
{
    public required object ViewModel { get; set; }
    public Position Position { get; set; } = Position.Left;
    public double? Size { get; set; }
}