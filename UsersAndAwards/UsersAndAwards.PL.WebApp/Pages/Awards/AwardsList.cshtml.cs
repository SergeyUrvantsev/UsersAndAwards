using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UsersAndAwards.Models;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.Dependencies;
using Microsoft.AspNetCore.Authorization;

namespace UsersAndAwards.PL.WebApp.Pages.Awards
{
    [Authorize]
    public class AwardsListModel : PageModel
    {
        private readonly IUsersAndAwardsLogic _bll;

        public AwardsListModel()
        {
            _bll = DependenciesResolver.Instance.UsersAndAwardsBLL;
        }

        public IList<AwardModel> Awards { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var awards = await _bll.GetAllAwardsQuery();

            if (!string.IsNullOrEmpty(SearchString))
            {
               awards = awards.Where(award => award.Title.Contains(SearchString));
            }

            Awards = awards.ToList();
        }
    }
}
