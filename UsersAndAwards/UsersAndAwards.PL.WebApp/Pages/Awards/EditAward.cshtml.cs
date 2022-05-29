using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UsersAndAwards.Models.Handlers;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.Dependencies;
using UsersAndAwards.Exceptions;

namespace UsersAndAwards.PL.WebApp.Pages.Awards
{
    public class EditAwardModel : PageModel
    {
        private readonly IUsersAndAwardsLogic _bll;

        public EditAwardModel()
        {
            _bll = DependenciesResolver.Instance.UsersAndAwardsBLL;
        }

        [BindProperty]
        public AwardEditHandler Award { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            try
            {
                var a = await _bll.GetAwardQuery(id);
                Award = new AwardEditHandler
                {
                    Id = a.Id,
                    Title = a.Title
                };
                return Page();
            }
            catch (NotFoundException ex)
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
                await _bll.UpdateAwardCommand(Award.Id, Award.Title);
            }
            catch (NotFoundException ex)
            {
                return NotFound();
            }

            return RedirectToPage("./AwardsList");
        }
    }
}
