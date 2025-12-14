namespace Jaguar.Core.Services.AppState
{
    public class AppStateService
    {
        public event Action? OnStateChanged;
        public bool isRightPanelOpen { get; private protected set; } =  true;
        
        public void ToggleRightPanelOpen()
        {
            Console.WriteLine("I am Clicked.");
            isRightPanelOpen =  !isRightPanelOpen;
            StateChanged();
        }
        
        
        private void StateChanged()
        {
            OnStateChanged?.Invoke();
        }
    }
}