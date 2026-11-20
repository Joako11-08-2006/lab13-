using Laboratorio13.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Laboratorio13.Controllers;

[ApiController]
[Route("api/students")]
public class StudentsApiController : ControllerBase
{
    private readonly AppDbContext _context;

    public StudentsApiController(AppDbContext context) => _context = context;

    // 8. GET api/students/search?firstName=&lastName=&email=
    // Busca por nombre, apellido y email; orden descendente por apellido.
    [HttpGet("search")]
    public async Task<IActionResult> Search(string firstName, string lastName, string email)
    {
        var query = _context.Students.AsQueryable();

        if (!string.IsNullOrWhiteSpace(firstName))
            query = query.Where(s => s.FirstName.ToLower().Contains(firstName.ToLower()));
        if (!string.IsNullOrWhiteSpace(lastName))
            query = query.Where(s => s.LastName.ToLower().Contains(lastName.ToLower()));
        if (!string.IsNullOrWhiteSpace(email))
            query = query.Where(s => s.Email.ToLower().Contains(email.ToLower()));

        var result = await query
            .OrderByDescending(s => s.LastName)
            .Select(s => new { s.IdStudent, s.IdGrade, s.FirstName, s.LastName, s.Phone, s.Email })
            .ToListAsync();

        return Ok(result);
    }

    // 9. GET api/students/by-name-grade?firstName=&grade=
    // Busca por nombre del estudiante y nombre del grado. Devuelve todos los datos del
    // estudiante, de su grado y de los cursos en que esta matriculado.
    // Orden descendente por nombre del curso (el mayor nombre de curso del estudiante),
    // y luego por nombre del estudiante descendente.
    [HttpGet("by-name-grade")]
    public async Task<IActionResult> ByNameAndGrade(string firstName, string grade)
    {
        var query = _context.Students.AsQueryable();

        if (!string.IsNullOrWhiteSpace(firstName))
            query = query.Where(s => s.FirstName.ToLower().Contains(firstName.ToLower()));
        if (!string.IsNullOrWhiteSpace(grade))
            query = query.Where(s => s.Grade.Name.ToLower().Contains(grade.ToLower()));

        var result = await query
            .OrderByDescending(s => s.Enrollments.Max(e => e.Course.Name))
            .ThenByDescending(s => s.FirstName)
            .Select(s => new
            {
                Student = new { s.IdStudent, s.FirstName, s.LastName, s.Phone, s.Email },
                Grade = new { s.Grade.IdGrade, s.Grade.Name, s.Grade.Description },
                Courses = s.Enrollments
                    .OrderByDescending(e => e.Course.Name)
                    .Select(e => new { e.Course.IdCourse, e.Course.Name, e.Course.Credit })
                    .ToList()
            })
            .ToListAsync();

        return Ok(result);
    }
}
