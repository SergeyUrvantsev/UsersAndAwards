using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.Dependencies;
using UsersAndAwards.Models.Handlers;

namespace UsersAndAwards.PL.WebApp.Pages.Awards
{
    [Authorize(Roles = "admin")]
    public class CreateAwardModel : PageModel
    {
        private readonly IUsersAndAwardsLogic _bll;

        public CreateAwardModel()
        {
            _bll = DependenciesResolver.Instance.UsersAndAwardsBLL;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AwardCreateHandler Award { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }


            await _bll.CreateAwardCommand(Award.Title);

            return RedirectToPage("./AwardsList");
        }
    }
}
