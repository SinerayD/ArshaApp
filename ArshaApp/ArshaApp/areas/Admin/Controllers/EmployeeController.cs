using ArshaApp.Context;
using ArshaApp.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ArshaApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly ArshaAppDbContext _context;

        public EmployeeController(ArshaAppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Employee> employees = await _context.Employees.Where(x => !x.IsDeleted).ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _context.AddAsync(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Employee employee = await _context.Employees.FindAsync(id);
            if (employee == null || employee.IsDeleted)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            Employee employeeToUpdate = await _context.Employees.FindAsync(id);
            if (employeeToUpdate == null || employeeToUpdate.IsDeleted)
            {
                return NotFound();
            }

            employeeToUpdate.FullName = employee.FullName;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Employee employee = await _context.Employees.FindAsync(id);
            if (employee == null || employee.IsDeleted)
            {
                return NotFound();
            }

            employee.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

