using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.JSInterop;
using System.Collections.Concurrent;

namespace UndecidedApp.Services
{
    public class ColorModeService : IColorModeService
    {

        private readonly string _colorModeKey = "theme";
        private readonly ConcurrentDictionary<string, string> _ColorModes = new ConcurrentDictionary<string, string>();

       
        public string GetCurrentColorMode()
        {
            if (_ColorModes.TryGetValue(_colorModeKey, out string mode))
            {
                return mode;
            }
            else
            {
                return "light";
            }
        }

        public bool SetCurrentColorMode(string mode)
        {
            bool result = false;
            if (_ColorModes.TryAdd(_colorModeKey, mode))
            {
                result = true;
            }else
            {
                result = _ColorModes.TryUpdate(_colorModeKey, mode, _ColorModes[_colorModeKey]);
            }
            return result;
        }
    }
}
