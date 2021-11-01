using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HobbiesRP.Data;
using HobbiesRP.Models;

namespace HobbiesRP.Pages.Hobbies
{
    public class CreateModel : PageModel
    {
        private readonly HobbiesRP.Data.HobbiesRPContext _context;

        public CreateModel(HobbiesRP.Data.HobbiesRPContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Hobby Hobby { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Hobby.Add(Hobby);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
