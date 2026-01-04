
namespace Jaguar.Desktop.Models;

public record RequestDialogMessage(FlowNode ParentNode);

public record RequestDeleteNodeMessage(FlowNode NodeToDelete);

public record RequestOpenPromptDialog(FlowNode NodeToOpen);

public record RequestAddNodeMessage(FlowNode NodeToAdd);
