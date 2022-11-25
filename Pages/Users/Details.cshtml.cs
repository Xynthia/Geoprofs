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
    public class DetailsModel : PageModel
    {
        private readonly GeoprofsXyn.Data.UserContext _context;

        public DetailsModel(GeoprofsXyn.Data.UserContext context)
        {
            _context = context;
        }

      public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }


            User = await _context.User.Where(x => x.Id == id.Value)
                                      .Include(x => x.Verlof)
                                      .Include(y => y.Team)
                                      .Include(z => z.Rol)
                                      .FirstOrDefaultAsync();

            if (User == null)
            {
                return NotFound();
            }
            else 
            {
                User = User;
            }
            return Page();
        }
    }
}
