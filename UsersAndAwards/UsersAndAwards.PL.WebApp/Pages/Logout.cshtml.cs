using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UsersAndAwards.PL.WebApp.Pages
{
    [Authorize]
    public class LogoutModel : PageModel
    {
        public LogoutModel(SignInManager<IdentityUser> signInManager) =>
            this.signInManager = signInManager;

        public SignInManager<IdentityUser> signInManager { get; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await signInManager.SignOutAsync();
            return RedirectToPage("./Index");
        }

        public IActionResult OnPostDontLogoutAsync()
        {
            return RedirectToPage("./Index");
        }
    }
}
