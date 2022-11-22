using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cozmaciuc_Mihai_Laborator2.Data;
using Cozmaciuc_Mihai_Laborator2.Models;

namespace Cozmaciuc_Mihai_Laborator2.Pages.Authors
{
    public class DetailsModel : PageModel
    {
        private readonly Cozmaciuc_Mihai_Laborator2.Data.Cozmaciuc_Mihai_Laborator2Context _context;

        public DetailsModel(Cozmaciuc_Mihai_Laborator2.Data.Cozmaciuc_Mihai_Laborator2Context context)
        {
            _context = context;
        }

      public Author Author { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Author == null)
            {
                return NotFound();
            }

            var author = await _context.Author.FirstOrDefaultAsync(m => m.ID == id);
            if (author == null)
            {
                return NotFound();
            }
            else 
            {
                Author = author;
            }
            return Page();
        }
    }
}
