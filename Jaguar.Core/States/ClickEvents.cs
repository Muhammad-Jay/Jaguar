namespace Jaguar.Core.States
{
    public static class ClickEvents
    {
        public static bool IsRightMenuOpen = true;
        
        public static void ToggleClick()
        {
            IsRightMenuOpen = false;
        }
    }
}