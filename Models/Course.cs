using System.ComponentModel.DataAnnotations;

namespace Laboratorio13.Models;

public class Course
{
    [Key]
    public int IdCourse { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(45)]
    public string Name { get; set; }

    [Range(0, 100)]
    [Display(Name = "Créditos")]
    public int Credit { get; set; }

    // Eliminación lógica
    public bool IsDeleted { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
