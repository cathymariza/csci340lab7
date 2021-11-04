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
    public class IndexModel : PageModel
    {
        private readonly HobbiesRP.Data.HobbiesRPContext _context;

        public IndexModel(HobbiesRP.Data.HobbiesRPContext context)
        {
            _context = context;
        }

        public IList<Hobby> Hobby { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Name { get; set; }
        [BindProperty(SupportsGet = true)]
        public string HobbyName { get; set; }


        public async Task OnGetAsync()
        {
            Hobby = await _context.Hobby.ToListAsync();
        }
    }
}
