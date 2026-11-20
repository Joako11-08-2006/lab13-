using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laboratorio13.Models;

public class Enrollment
{
    [Key]
    public int IdEnrollment { get; set; }

    // Llaves foráneas
    public int IdStudent { get; set; }
    public int IdCourse { get; set; }

    [ForeignKey(nameof(IdStudent))]
    public Student Student { get; set; }

    [ForeignKey(nameof(IdCourse))]
    public Course Course { get; set; }

    public DateTime Date { get; set; }
}
