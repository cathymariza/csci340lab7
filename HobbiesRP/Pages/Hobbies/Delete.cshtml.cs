using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HobbiesRP.Data;
using HobbiesRP.Models;

namespace HobbiesRP.Pages.Hobbies
{
    public class DeleteModel : PageModel
    {
        private readonly HobbiesRP.Data.HobbiesRPContext _context;

        public DeleteModel(HobbiesRP.Data.HobbiesRPContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hobby = await _context.Hobby.FindAsync(id);

            if (Hobby != null)
            {
                _context.Hobby.Remove(Hobby);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
