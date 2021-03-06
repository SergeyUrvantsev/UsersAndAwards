using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UsersAndAwards.Models;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.Dependencies;
using UsersAndAwards.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace UsersAndAwards.PL.WebApp.Pages.Users
{
    [Authorize]
    public class DetailsUserModel : PageModel
    {
        private readonly IUsersAndAwardsLogic _bll;

        public DetailsUserModel()
        {
            _bll = DependenciesResolver.Instance.UsersAndAwardsBLL;
        }

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

    }
}
