using CommunityToolkit.Mvvm.ComponentModel;

namespace Jaguar.Desktop.Models.Ui;

public partial class WorkflowTemplate: ObservableObject
{
    public string Title { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;

    public WorkflowTemplateType Type { get; init; } = WorkflowTemplateType.BlankTemplate;

    [ObservableProperty] private bool _isSelected;
}

public enum WorkflowTemplateType
{
    BlankTemplate,
    NodeSystem,
    StateMachine,
    DataPipeline,
    FromTemplate
}