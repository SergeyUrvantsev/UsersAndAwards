using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UsersAndAwards.Models;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.Dependencies;
using UsersAndAwards.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace UsersAndAwards.PL.WebApp.Pages.Awards
{
    [Authorize(Roles = "admin")]
    public class DeleteAwardModel : PageModel
    {
        private readonly IUsersAndAwardsLogic _bll;

        public DeleteAwardModel()
        {
            _bll = DependenciesResolver.Instance.UsersAndAwardsBLL;
        }

        [BindProperty]
        public AwardModel Award { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            try
            {
                Award = await _bll.GetAwardQuery(id);
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
                await _bll.DeleteAwardCommand(id);
                return RedirectToPage("./AwardsList");
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }



    }
}
