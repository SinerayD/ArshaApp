using Microsoft.AspNetCore.Mvc;

namespace ArshaApp.areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
