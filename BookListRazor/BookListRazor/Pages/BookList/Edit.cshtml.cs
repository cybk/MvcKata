using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor
{
    public class EditModel : PageModel
    {
        private AppDbContext _db;

        public EditModel(AppDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task OnGet(int id)
        {
            Book = await _db.Book.FindAsync(id);
        }

        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var book = await _db.Book.FindAsync(Book.Id);
                book.Name = Book.Name;
                book.Author = Book.Author;
                book.ISBN = book.ISBN;

                await _db.SaveChangesAsync();

                return Redirect("Index");
            }

            return RedirectToPage();
        }
    }
}