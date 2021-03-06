using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UsersAndAwards.Models.Handlers;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.Dependencies;
using UsersAndAwards.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace UsersAndAwards.PL.WebApp.Pages.Users
{
    [Authorize(Roles = "admin")]
    public class EditUserModel : PageModel
    {
        private readonly IUsersAndAwardsLogic _bll;

        public EditUserModel()
        {
            _bll = DependenciesResolver.Instance.UsersAndAwardsBLL;
        }

        [BindProperty]
        public UserEditHandler User { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            try
            {
                var a = await _bll.GetUserQuery(id);
                User = new UserEditHandler
                {
                    Id = a.Id,
                    Name = a.Name,
                    DateOfBirth = a.DateOfBirth
                };
                return Page();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _bll.UpdateUserCommand(User.Id, User.Name, User.DateOfBirth);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return RedirectToPage("./UsersList");
        }

    }
}
