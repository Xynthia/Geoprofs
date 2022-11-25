using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GeoprofsXyn.Data;
using GeoprofsXyn.Models;

namespace GeoprofsXyn.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly GeoprofsXyn.Data.UserContext _context;

        public EditModel(GeoprofsXyn.Data.UserContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user =  await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var userToUpdate = await _context.User.FindAsync(id);

            if (userToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<User>(
                userToUpdate,
                "User",
                s => s.Naam, s => s.Email, s => s.Wachtwoord, s => s.VerlofUren))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool UserExists(int id)
        {
          return _context.User.Any(e => e.Id == id);
        }
    }
}
