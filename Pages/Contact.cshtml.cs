using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UndecidedApp.Data;

namespace UndecidedApp.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IHttpContextAccessor _context;

        public IDictionary<string, string?>  properties { get; set; }
        public string message { get; set; } = String.Empty;

        public ContactModel(IHttpContextAccessor context)
        {
            _context = context;
        }
        public async void OnGetAsync()
        {
            try
            {
                var authResult = await _context.HttpContext.AuthenticateAsync();

                if (authResult?.Principal != null && authResult.Properties != null)
                {
                    properties = authResult.Properties.Items;
                }
            }
            catch (Exception ex) {
                message = ex.Message;
            }

          
        }
    }
}
