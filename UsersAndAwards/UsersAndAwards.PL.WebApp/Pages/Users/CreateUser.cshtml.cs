using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.Dependencies;
using UsersAndAwards.Models.Handlers;

namespace UsersAndAwards.PL.WebApp.Pages.Users
{
    [Authorize(Roles = "admin")]
    public class CreateUserModel : PageModel
    {
        private readonly IUsersAndAwardsLogic _bll;

        public CreateUserModel()
        {
            _bll = DependenciesResolver.Instance.UsersAndAwardsBLL;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UserCreateHandler User { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }


            await _bll.CreateUserCommand(User.Name, User.DateOfBirth);

            return RedirectToPage("./UsersList");
        }

    }
}
