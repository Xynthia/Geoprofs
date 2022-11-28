using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GeoprofsXyn.Models;
using GeoprofsXyn.Models.UserViewModels;
using GeoprofsXyn.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoprofsXyn.Pages
{
    public class AboutModel : PageModel
    {
        public readonly UserContext _context;

        public AboutModel(UserContext context)
        {
            _context = context;
        }

        public IList<VerlofDatumGroup> users { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<VerlofDatumGroup> data =
                from Verlof in _context.Verlof
                group Verlof by Verlof.BeginDatum into dateGroup
                select new VerlofDatumGroup()
                {
                    VerlofBeginDatum = dateGroup.Key,
                    VerlofCount = dateGroup.Count()
                };

            users = await data.AsNoTracking().ToListAsync();


        }

    }
}
