using ArshaApp.Context;
using ArshaApp.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ArshaApp.areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialmediaController : Controller
    {
        private readonly ArshaAppDbContext _context;

        public SocialmediaController(ArshaAppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<SocialMedia> socialMedias = await _context.SocialMedias.Where(x => !x.IsDeleted).ToListAsync();
            return View(socialMedias);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SocialMedia socialMedia)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _context.SocialMedias.AddAsync(socialMedia);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            SocialMedia socialMedia = await _context.SocialMedias.FindAsync(id);
            if (socialMedia == null || socialMedia.IsDeleted)
            {
                return NotFound();
            }

            return View(socialMedia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, SocialMedia socialMedia)
        {
            if (!ModelState.IsValid)
            {
                return View(socialMedia);
            }

            SocialMedia socialMediaToUpdate = await _context.SocialMedias.FindAsync(id);
            if (socialMediaToUpdate == null || socialMediaToUpdate.IsDeleted)
            {
                return NotFound();
            }

            socialMediaToUpdate.Name = socialMedia.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            SocialMedia socialMedia = await _context.SocialMedias.FindAsync(id);
            if (socialMedia == null || socialMedia.IsDeleted)
            {
                return NotFound();
            }

            socialMedia.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

