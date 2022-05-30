using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UsersAndAwards.Models;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.Dependencies;
using UsersAndAwards.Exceptions;

namespace UsersAndAwards.PL.WebApp.Pages.Users
{
    public class RemoveAwardModel : PageModel
    {
        private readonly IUsersAndAwardsLogic _bll;

        public RemoveAwardModel()
        {
            _bll = DependenciesResolver.Instance.UsersAndAwardsBLL;
        }


        [BindProperty(Name = "item.Id")]
        public Guid item_id { get; set; }

        public List<AwardModel> Awards { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {

            var awardsList = await _bll.GetAllAwardsQuery();

            if (!string.IsNullOrEmpty(SearchString))
            {
                awardsList = awardsList
                    .Where(award => award.Title.Contains(SearchString));
            }

            Awards = awardsList
                .Where(award => award.Users.Any(user => user.Id == id))
                .ToList();

            return Page();
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            try
            {
                await _bll.RemoveAwardAtUser(id, item_id);
            }
            catch (NotFoundException ex)
            {
                return NotFound();
            }

            return RedirectToPage("./UsersList");
        }
    }
}
