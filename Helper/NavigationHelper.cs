using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace UndecidedApp.Helper
{

    
    public class NavigationHelper
    {

        private readonly NavigationManager _navManager;

        public NavigationHelper(NavigationManager navManager)
        {
            _navManager = navManager;
        }


        public void NavigateToPage(string url)
        {
             _navManager.NavigateTo(url);
        }

      


    }
}
