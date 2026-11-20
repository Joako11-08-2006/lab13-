using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laboratorio13.Models;

public class Student
{
    [Key]
    public int IdStudent { get; set; }

    // Llave foránea hacia Grade
    public int IdGrade { get; set; }

    [ForeignKey(nameof(IdGrade))]
    public Grade Grade { get; set; }

    [Required]
    [StringLength(45)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(45)]
    public string LastName { get; set; }

    [StringLength(45)]
    public string Phone { get; set; }

    [EmailAddress]
    [StringLength(45)]
    public string Email { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
