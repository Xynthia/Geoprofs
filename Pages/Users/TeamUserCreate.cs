using GeoprofsXyn.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GeoprofsXyn.Pages.Users
{
    public class TeamUserCreate : PageModel
    {
        public SelectList TeamSl { get; set; }

        public void PopulateTeamDropDownList(UserContext _context, object selectedTeam = null)
        {
            var teamsQuery = from d in _context.Team
                             orderby d.Naam
                             select d;

            TeamSl = new SelectList(teamsQuery.AsNoTracking(), "TeamId", "Naam", selectedTeam);
        }
    }
}
