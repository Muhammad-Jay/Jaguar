
using Jaguar.Desktop.ViewModels;

namespace Jaguar.Desktop.Models;

public record RequestDialogMessage(FlowNodeViewModel ParentNode);

public record RequestDeleteNodeMessage(FlowNodeViewModel NodeToDelete);

public record RequestOpenPromptDialog(FlowNodeViewModel NodeToOpen);

public record RequestAddNodeMessage(FlowNodeViewModel NodeToAdd);
