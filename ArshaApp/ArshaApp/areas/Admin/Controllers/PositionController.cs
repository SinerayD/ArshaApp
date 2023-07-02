using ArshaApp.Context;
using ArshaApp.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArshaApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PositionController : Controller
    {
        private readonly ArshaAppDbContext _context;

        public PositionController(ArshaAppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Position> positions = await _context.Positions.Where(x => !x.IsDeleted).ToListAsync();
            return View(positions);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Position position)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _context.Positions.AddAsync(position);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Position position = await _context.Positions.FindAsync(id);
            if (position == null || position.IsDeleted)
            {
                return NotFound();
            }

            return View(position);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Position position)
        {
            if (!ModelState.IsValid)
            {
                return View(position);
            }

            Position positionToUpdate = await _context.Positions.FindAsync(id);
            if (positionToUpdate == null || positionToUpdate.IsDeleted)
            {
                return NotFound();
            }

            positionToUpdate.Name = position.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Position position = await _context.Positions.FindAsync(id);
            if (position == null || position.IsDeleted)
            {
                return NotFound();
            }

            position.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
