namespace UndecidedApp.Services
{
    public interface IColorModeService
    {
        string GetCurrentColorMode();
        bool SetCurrentColorMode(string mode);
    }
}
