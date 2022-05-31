using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UsersAndAwards.Models;

namespace UsersAndAwards.PL.WebApp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login Model { get; set; }
        public SignInManager<IdentityUser> signInManager { get; }

        public LoginModel(SignInManager<IdentityUser> signInManager) =>
            this.signInManager = signInManager;


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var identityResult = await signInManager.PasswordSignInAsync(Model.Email, Model.Password, Model.RememberMe, false);

                if(identityResult.Succeeded)
                {
                    return RedirectToPage("./Index");
                    if (returnUrl == null || returnUrl == "/")
                    {
                        return RedirectToPage("./Index");
                    }
                    else
                    {
                        return RedirectToPage(returnUrl);
                    }
                }

                ModelState.AddModelError("", "Username or password incorrect");
            }

            return Page();
        }
    }
}
