using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using ArshaApp.Context;
using ArshaApp.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArshaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ArshaAppDbContext _context;

        public HomeController(ArshaAppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> categories = await _context.Categories.Where(x => !x.IsDeleted).ToListAsync();
            return View(categories);
        }
    }
}
