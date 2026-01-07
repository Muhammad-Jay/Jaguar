using Jaguar.Core.Models.Graph;
using Jaguar.Desktop.Models.Ui;

namespace Jaguar.Desktop.Services.Events.Ui;

public record OpenAgentTemplateDialogEvent;
public record CloseDialogEvent;

public record OpenPanelEvent(
    object ViewModel,
    Position Position,
    double? Size = 350
);

public record DeleteNodeEvent(string NodeId);

public record AddNodeEvent(string Id);