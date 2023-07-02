using Microsoft.AspNetCore.Mvc;

namespace ArshaApp.areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
