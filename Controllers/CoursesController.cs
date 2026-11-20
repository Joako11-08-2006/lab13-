using Laboratorio13.Data;
using Laboratorio13.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Laboratorio13.Controllers;

public class CoursesController : Controller
{
    private readonly AppDbContext _context;

    public CoursesController(AppDbContext context) => _context = context;

    // GET: Courses
    public async Task<IActionResult> Index() => View(await _context.Courses.ToListAsync());

    // GET: Courses/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var item = await _context.Courses.FirstOrDefaultAsync(m => m.IdCourse == id);
        return item == null ? NotFound() : View(item);
    }

    // GET: Courses/Create
    public IActionResult Create() => View();

    // POST: Courses/Create
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,Credit")] Course course)
    {
        if (!ModelState.IsValid) return View(course);
        _context.Add(course);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // GET: Courses/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var item = await _context.Courses.FindAsync(id);
        return item == null ? NotFound() : View(item);
    }

    // POST: Courses/Edit/5
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("IdCourse,Name,Credit")] Course course)
    {
        if (id != course.IdCourse) return NotFound();
        if (!ModelState.IsValid) return View(course);

        var entity = await _context.Courses.FindAsync(id);
        if (entity == null) return NotFound();
        entity.Name = course.Name;
        entity.Credit = course.Credit;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // GET: Courses/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var item = await _context.Courses.FirstOrDefaultAsync(m => m.IdCourse == id);
        return item == null ? NotFound() : View(item);
    }

    // POST: Courses/Delete/5  -> ELIMINACIÓN LÓGICA (IsDeleted = true)
    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var item = await _context.Courses.FindAsync(id);
        if (item != null)
        {
            item.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
