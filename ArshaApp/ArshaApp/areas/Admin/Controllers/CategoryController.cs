using ArshaApp.Context;
using ArshaApp.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArshaApp.areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ArshaAppDbContext _context;

        public CategoryController(ArshaAppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> categories = await _context.Categories.Where(x => !x.IsDeleted).ToListAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Category? category = await _context.Categories.Where(x=> !x.IsDeleted && x.Id == id)
                .FirstOrDefaultAsync();
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Category postcategory)
        {
            if (!ModelState.IsValid)
            {
                return View(postcategory);
            }

            Category? category = await _context.Categories.Where(x => !x.IsDeleted && x.Id == id)
                .FirstOrDefaultAsync();
            if (category == null)
            {
                return NotFound();
            }

            category.Name = postcategory.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Category");
        }
        [HttpGet]

        public async Task<IActionResult> Delete(int id)
        {
            Category? category = await _context.Categories.Where(x => !x.IsDeleted && x.Id == id)
               .FirstOrDefaultAsync();
            if (category == null)
            {
                return NotFound();
            }
            // _context.Categories.Remove(category);
            category.IsDeleted = true;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}

