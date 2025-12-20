using Jaguar.Desktop.Models.Ui;

namespace Jaguar.Desktop.Abstractions;

public interface IAppStateService
{
    PanelRequest ActivePanel { get; set; }
    void RequestPanel(object viewModel, Position pos, double? size);
    void ClosePanel();
}