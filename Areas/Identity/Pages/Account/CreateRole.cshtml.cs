using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using System.ComponentModel.DataAnnotations;
using UndecidedApp.Data.Models.AuthModels;

namespace UndecidedApp.Areas.Identity.Pages.Account
{

    public class CreateRoleModel : PageModel
    {


        private readonly RoleManager<ApplicationRole> _roleManager;
        public string? ReturnUrl { get; set; }
        public string? Message { get; set; } = String.Empty;

        [BindProperty]
        public InputModel Input { get; set; }

        public CreateRoleModel(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [Display(Name = "Name")]
            public string Name { get; set; }
        }


        public async Task OnGetAsync(string? returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                ApplicationRole newRole = new ApplicationRole();
                newRole.Name = Input.Name;

                IdentityResult result = await _roleManager.CreateAsync(newRole);
                if (result.Succeeded)
                {
                    Message = "Role Created Successfully";
                    return Page();
                }
                else
                {
                    foreach(IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return Page();
        }

    }
}
