using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cozmaciuc_Mihai_Laborator2.Data;
using Cozmaciuc_Mihai_Laborator2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cozmaciuc_Mihai_Laborator2.Pages.Books
{
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Cozmaciuc_Mihai_Laborator2.Data.Cozmaciuc_Mihai_Laborator2Context _context;

        public CreateModel(Cozmaciuc_Mihai_Laborator2.Data.Cozmaciuc_Mihai_Laborator2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
 //            var authorList = _context.Author.Select(x => new
 //{
 //x.ID,
 //FullName = x.LastName + " " + x.FirstName
 //});

            // daca am adaugat o proprietate FullName in clasa Author 
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID", "AuthorName");/*FullName*/
            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, book);
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBook = new Book();
            if (selectedCategories != null)
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }
            Book.BookCategories = newBook.BookCategories;
            _context.Book.Add(Book);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
        PopulateAssignedCategoryData(_context, newBook);
        return Page();
    }
}