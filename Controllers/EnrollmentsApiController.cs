using Laboratorio13.Data;
using Laboratorio13.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Laboratorio13.Controllers;

[ApiController]
[Route("api/enrollments")]
public class EnrollmentsApiController : ControllerBase
{
    private readonly AppDbContext _context;

    public EnrollmentsApiController(AppDbContext context) => _context = context;

    // 10. GET api/enrollments/by-course?course=
    [HttpGet("by-course")]
    public async Task<IActionResult> ByCourse(string course)
    {
        var query = _context.Enrollments.AsQueryable();
        if (!string.IsNullOrWhiteSpace(course))
            query = query.Where(e => e.Course.Name.ToLower().Contains(course.ToLower()));

        return Ok(await Project(query));
    }

    // 11. GET api/enrollments/by-grade?grade=
    [HttpGet("by-grade")]
    public async Task<IActionResult> ByGrade(string grade)
    {
        var query = _context.Enrollments.AsQueryable();
        if (!string.IsNullOrWhiteSpace(grade))
            query = query.Where(e => e.Student.Grade.Name.ToLower().Contains(grade.ToLower()));

        return Ok(await Project(query));
    }

    // Ordena por curso y luego por apellido, y devuelve estudiante + curso + matrícula
    private static async Task<List<object>> Project(IQueryable<Enrollment> query)
    {
        var data = await query
            .OrderBy(e => e.Course.Name)
            .ThenBy(e => e.Student.LastName)
            .Select(e => new
            {
                Student = new { e.Student.IdStudent, e.Student.FirstName, e.Student.LastName, e.Student.Phone, e.Student.Email, Grade = e.Student.Grade.Name },
                Course = new { e.Course.IdCourse, e.Course.Name, e.Course.Credit },
                Enrollment = new { e.IdEnrollment, e.Date }
            })
            .ToListAsync();

        return data.Cast<object>().ToList();
    }
}
