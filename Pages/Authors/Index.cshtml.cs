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
    public class IndexModel : PageModel
    {
        private readonly Cozmaciuc_Mihai_Laborator2.Data.Cozmaciuc_Mihai_Laborator2Context _context;

        public IndexModel(Cozmaciuc_Mihai_Laborator2.Data.Cozmaciuc_Mihai_Laborator2Context context)
        {
            _context = context;
        }

        public IList<Author> Author { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Author != null)
            {
                Author = await _context.Author.ToListAsync();
            }
        }
    }
}
