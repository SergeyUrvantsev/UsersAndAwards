using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UsersAndAwards.Models;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.Dependencies;
using UsersAndAwards.Exceptions;

namespace UsersAndAwards.PL.WebApp.Pages.Users
{
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
            catch (NotFoundException ex)
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
            catch (NotFoundException ex)
            {
                return NotFound();
            }
        }



    }
}
