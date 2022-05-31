using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UsersAndAwards.Models;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.Dependencies;
using UsersAndAwards.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace UsersAndAwards.PL.WebApp.Pages.Users
{
    [Authorize(Roles = "admin")]
    public class DeleteUserModel : PageModel
    {
        private readonly IUsersAndAwardsLogic _bll;

        public DeleteUserModel()
        {
            _bll = DependenciesResolver.Instance.UsersAndAwardsBLL;
        }

        [BindProperty]
        public UserModel User { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            try
            {
                User = await _bll.GetUserQuery(id);
                return Page();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            try
            {
                await _bll.DeleteUserCommand(id);
                return RedirectToPage("./UsersList");
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }



    }
}
