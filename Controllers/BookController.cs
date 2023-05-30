using Microsoft.AspNetCore.Mvc;

namespace LibraryRazor.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
