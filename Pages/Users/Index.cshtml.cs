using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GeoprofsXyn.Data;
using GeoprofsXyn.Models;

namespace GeoprofsXyn.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly GeoprofsXyn.Data.UserContext _context;

        public IndexModel(GeoprofsXyn.Data.UserContext context)
        {
            _context = context;
        }

        public string naamSort { get; set; }
        public string datumSort { get; set; }
        public string currentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<User> Users { get; set; } = default!;

        public async Task OnGetAsync(string soortOrder, string searchString)
        {
            naamSort = String.IsNullOrEmpty(soortOrder) ? "naam_desc" : "";
            datumSort = soortOrder == "VerlofUren" ? "verlofUren_desc" : "VerlofUren";

            currentFilter = searchString;

            IQueryable<User> UserIQ = from u in _context.User select u;

            if (!String.IsNullOrEmpty(searchString))
            {
                UserIQ = UserIQ.Where(s => s.Naam.Contains(searchString));
            }

            switch (soortOrder)
            {
                case "naam_desc":
                    UserIQ = UserIQ.OrderByDescending(s => s.Naam);
                    break;
                case "BeginDatum":
                    UserIQ = UserIQ.OrderBy(s => s.VerlofUren);
                    break;
                case "date_desc":
                    UserIQ = UserIQ.OrderByDescending(s => s.VerlofUren);
                    break;
                default:
                    UserIQ = UserIQ.OrderBy(s => s.Naam);
                    break;
            }

            Users = await UserIQ.AsNoTracking().ToListAsync();
        }
    }
}
