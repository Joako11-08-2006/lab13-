using Laboratorio13.Data;
using Laboratorio13.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Laboratorio13.Controllers;

public class GradesController : Controller
{
    private readonly AppDbContext _context;

    public GradesController(AppDbContext context) => _context = context;

    // GET: Grades
    public async Task<IActionResult> Index() => View(await _context.Grades.ToListAsync());

    // GET: Grades/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var item = await _context.Grades.FirstOrDefaultAsync(m => m.IdGrade == id);
        return item == null ? NotFound() : View(item);
    }

    // GET: Grades/Create
    public IActionResult Create() => View();

    // POST: Grades/Create
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,Description")] Grade grade)
    {
        if (!ModelState.IsValid) return View(grade);
        _context.Add(grade);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // GET: Grades/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var item = await _context.Grades.FindAsync(id);
        return item == null ? NotFound() : View(item);
    }

    // POST: Grades/Edit/5
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("IdGrade,Name,Description")] Grade grade)
    {
        if (id != grade.IdGrade) return NotFound();
        if (!ModelState.IsValid) return View(grade);

        var entity = await _context.Grades.FindAsync(id);
        if (entity == null) return NotFound();
        entity.Name = grade.Name;
        entity.Description = grade.Description;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // GET: Grades/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var item = await _context.Grades.FirstOrDefaultAsync(m => m.IdGrade == id);
        return item == null ? NotFound() : View(item);
    }

    // POST: Grades/Delete/5  -> ELIMINACIÓN LÓGICA (IsDeleted = true)
    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var item = await _context.Grades.FindAsync(id);
        if (item != null)
        {
            item.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
