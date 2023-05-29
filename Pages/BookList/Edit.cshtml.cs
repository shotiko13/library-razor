using LibraryRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)  
        {
            _db = db;
        }

        public Book Book { get; set; }
        public async void OnGet(int Id)
        {
            Book = await _db.Book.FindAsync(Id);
        }

        public async Task<IActionResult> onPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = await _db.Book.FindAsync(Book.Id);
                BookFromDb.Name = Book.Name;
                BookFromDb.ISBN = Book.ISBN;
                BookFromDb.Author = Book.Author;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
