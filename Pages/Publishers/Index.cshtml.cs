using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cozmaciuc_Mihai_Laborator2.Data;
using Cozmaciuc_Mihai_Laborator2.Models;
using Cozmaciuc_Mihai_Laborator2.ViewModels;

namespace Cozmaciuc_Mihai_Laborator2.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Cozmaciuc_Mihai_Laborator2.Data.Cozmaciuc_Mihai_Laborator2Context _context;

        public IndexModel(Cozmaciuc_Mihai_Laborator2.Data.Cozmaciuc_Mihai_Laborator2Context context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get; set; } = default!;

        public PublisherIndexData PublisherData { get; set; }
        public int PublisherID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            PublisherData = new PublisherIndexData();
            PublisherData.Publishers = await _context.Publisher
            .Include(i => i.Books)
            .ThenInclude(c => c.Author)
            .OrderBy(i => i.PublisherName)
            .ToListAsync();
            if (id != null)
            {
                PublisherID = id.Value;
                Publisher publisher = PublisherData.Publishers
                .Where(i => i.ID == id.Value).Single();
                PublisherData.Books = publisher.Books;
            }

        }
    }
}