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
        private readonly IConfiguration _configuration;

        public IndexModel(GeoprofsXyn.Data.UserContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public string NaamSort { get; set; }
        public string DatumSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<User> Users { get; set; } = default!;

        public async Task OnGetAsync(string soortOrder, string searchString, string currentFilter, int? pageIndex)
        {
            CurrentSort = soortOrder;
            NaamSort = String.IsNullOrEmpty(soortOrder) ? "naam_desc" : "";
            DatumSort = soortOrder == "VerlofUren" ? "verlofUren_desc" : "VerlofUren";

            if(searchString != null)
            {
                    pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

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

            var pageSize = _configuration.GetValue("PageSize", 4);
            Users = await PaginatedList<User>.CreateAsync(UserIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
