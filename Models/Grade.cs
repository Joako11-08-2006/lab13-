using System.ComponentModel.DataAnnotations;

namespace Laboratorio13.Models;

public class Grade
{
    [Key]
    public int IdGrade { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(45)]
    public string Name { get; set; }

    [StringLength(45)]
    [Display(Name = "Descripción")]
    public string Description { get; set; }

    // Eliminación lógica
    public bool IsDeleted { get; set; }

    public ICollection<Student> Students { get; set; } = new List<Student>();
}
