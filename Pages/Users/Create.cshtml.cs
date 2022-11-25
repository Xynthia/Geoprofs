using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GeoprofsXyn.Data;
using GeoprofsXyn.Models;

namespace GeoprofsXyn.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly GeoprofsXyn.Data.UserContext _context;

        public CreateModel(GeoprofsXyn.Data.UserContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyUser = new User();

            try
            {
                var canGetUser = await TryUpdateModelAsync<User>(
                emptyUser,
                "User",
                s => s.Naam, s => s.Email, s => s.Wachtwoord, s => s.VerlofUren);

                if (canGetUser)
                {
                    _context.User.Add(emptyUser);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("./Index");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
                
            return Page();
        }
    }
}
