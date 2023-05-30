using LibraryRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryRazor.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {   
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db) 
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            return Json(new {data = await _db.Book.ToListAsync()});
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) 
        {
            var bookFromDb = await _db.Book.FirstOrDefaultAsync(x => x.Id == id);
            if (bookFromDb != null)
            {
                _db.Book.Remove(bookFromDb);
                await _db.SaveChangesAsync();
                return Json(new {success = true, message="Successful deletion"});

            }
            return Json( new {success = false, message="Error deleting"} );
        }
    }
}
