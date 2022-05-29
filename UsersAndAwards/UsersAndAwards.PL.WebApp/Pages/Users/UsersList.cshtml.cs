using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UsersAndAwards.Models;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.Dependencies;

namespace UsersAndAwards.PL.WebApp.Pages
{
    public class UsersListModel : PageModel
    {

        private readonly IUsersAndAwardsLogic _bll;

        public UsersListModel()
        {
            _bll = DependenciesResolver.Instance.UsersAndAwardsBLL;
        }

        public IList<UserModel> Users { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public SelectList Titles { get; set; }

        [BindProperty(SupportsGet = true)]
        public string AwardTitle { get; set; }

        public async Task OnGetAsync()
        {
            var users = await _bll.GetAllUsersQuery();

            if (!string.IsNullOrEmpty(SearchString))
            {
                users = users.Where(user => user.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(AwardTitle))
            {
                users = users.Where(x => x.Awards.Any(award => award.Title == AwardTitle));
            }

            Titles = new SelectList(_bll.GetAllTitleQuery());

            Users = users.ToList();
        }
    }
}
