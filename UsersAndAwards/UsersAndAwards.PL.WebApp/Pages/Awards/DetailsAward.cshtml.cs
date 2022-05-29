using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UsersAndAwards.Models;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.Dependencies;
using UsersAndAwards.Exceptions;

namespace UsersAndAwards.PL.WebApp.Pages.Awards
{
    public class DetailsAwardModel : PageModel
    {
        private readonly IUsersAndAwardsLogic _bll;

        public DetailsAwardModel()
        {
            _bll = DependenciesResolver.Instance.UsersAndAwardsBLL;
        }

        public AwardModel Award { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            try
            {
                Award = await _bll.GetAwardQuery(id);
                return Page();
            }
            catch (NotFoundException ex)
            {
                return NotFound();
            }
        }
    }
}
