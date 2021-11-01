using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HobbiesRP.Data;
using HobbiesRP.Models;

namespace HobbiesRP.Pages.Hobbies
{
    public class EditModel : PageModel
    {
        private readonly HobbiesRP.Data.HobbiesRPContext _context;

        public EditModel(HobbiesRP.Data.HobbiesRPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Hobby Hobby { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hobby = await _context.Hobby.FirstOrDefaultAsync(m => m.ID == id);

            if (Hobby == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Hobby).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HobbyExists(Hobby.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool HobbyExists(int id)
        {
            return _context.Hobby.Any(e => e.ID == id);
        }
    }
}
