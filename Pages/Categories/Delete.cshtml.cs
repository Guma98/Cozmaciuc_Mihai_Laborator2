﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cozmaciuc_Mihai_Laborator2.Data;
using Cozmaciuc_Mihai_Laborator2.Models;

namespace Cozmaciuc_Mihai_Laborator2.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly Cozmaciuc_Mihai_Laborator2.Data.Cozmaciuc_Mihai_Laborator2Context _context;

        public DeleteModel(Cozmaciuc_Mihai_Laborator2.Data.Cozmaciuc_Mihai_Laborator2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Category == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);

            if (category == null)
            {
                return NotFound();
            }
            else 
            {
                Category = category;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Category == null)
            {
                return NotFound();
            }
            var category = await _context.Category.FindAsync(id);

            if (category != null)
            {
                Category = category;
                _context.Category.Remove(Category);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
