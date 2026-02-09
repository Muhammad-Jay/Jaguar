using Jaguar.Desktop.Models.Ui;

namespace Jaguar.Desktop.Services.Events.Ui;

public record OpenPanelEvent(
    object ViewModel,
    Position Position,
    double? Size = 350
);