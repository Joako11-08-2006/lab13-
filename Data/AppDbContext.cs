using Laboratorio13.Models;
using Microsoft.EntityFrameworkCore;

namespace Laboratorio13.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Grade> Grades { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        // Filtros globales: los registros "eliminados" no aparecen en ninguna consulta
        mb.Entity<Grade>().HasQueryFilter(g => !g.IsDeleted);
        mb.Entity<Course>().HasQueryFilter(c => !c.IsDeleted);

        mb.Entity<Student>()
            .HasOne(s => s.Grade).WithMany(g => g.Students)
            .HasForeignKey(s => s.IdGrade).OnDelete(DeleteBehavior.Restrict);

        mb.Entity<Enrollment>()
            .HasOne(e => e.Student).WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.IdStudent).OnDelete(DeleteBehavior.Restrict);

        mb.Entity<Enrollment>()
            .HasOne(e => e.Course).WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.IdCourse).OnDelete(DeleteBehavior.Restrict);

        // Datos de ejemplo (útiles para la base en memoria)
        mb.Entity<Grade>().HasData(
            new Grade { IdGrade = 1, Name = "Primero", Description = "Primer grado" },
            new Grade { IdGrade = 2, Name = "Segundo", Description = "Segundo grado" },
            new Grade { IdGrade = 3, Name = "Tercero", Description = "Tercer grado" },
            new Grade { IdGrade = 4, Name = "Cuarto", Description = "Cuarto grado" },
            new Grade { IdGrade = 5, Name = "Quinto", Description = "Quinto grado" });

        mb.Entity<Course>().HasData(
            new Course { IdCourse = 1, Name = "Matemática", Credit = 4 },
            new Course { IdCourse = 2, Name = "Comunicación", Credit = 3 },
            new Course { IdCourse = 3, Name = "Historia", Credit = 2 },
            new Course { IdCourse = 4, Name = "Ciencias", Credit = 4 },
            new Course { IdCourse = 5, Name = "Inglés", Credit = 3 },
            new Course { IdCourse = 6, Name = "Arte", Credit = 2 },
            new Course { IdCourse = 7, Name = "Educación Física", Credit = 2 },
            new Course { IdCourse = 8, Name = "Computación", Credit = 3 });

        mb.Entity<Student>().HasData(
            new Student { IdStudent = 1, IdGrade = 1, FirstName = "Ana", LastName = "Torres", Phone = "911100000", Email = "ana.torres1@mail.com" },
            new Student { IdStudent = 2, IdGrade = 2, FirstName = "Luis", LastName = "Castillo", Phone = "911237531", Email = "luis.castillo2@mail.com" },
            new Student { IdStudent = 3, IdGrade = 3, FirstName = "María", LastName = "Medina", Phone = "911375062", Email = "maria.medina3@mail.com" },
            new Student { IdStudent = 4, IdGrade = 4, FirstName = "Carlos", LastName = "Ramírez", Phone = "911512593", Email = "carlos.ramirez4@mail.com" },
            new Student { IdStudent = 5, IdGrade = 5, FirstName = "José", LastName = "Mendoza", Phone = "911650124", Email = "jose.mendoza5@mail.com" },
            new Student { IdStudent = 6, IdGrade = 1, FirstName = "Lucía", LastName = "Vargas", Phone = "911787655", Email = "lucia.vargas6@mail.com" },
            new Student { IdStudent = 7, IdGrade = 2, FirstName = "Pedro", LastName = "Gómez", Phone = "911925186", Email = "pedro.gomez7@mail.com" },
            new Student { IdStudent = 8, IdGrade = 3, FirstName = "Rosa", LastName = "Paredes", Phone = "912062717", Email = "rosa.paredes8@mail.com" },
            new Student { IdStudent = 9, IdGrade = 4, FirstName = "Miguel", LastName = "Silva", Phone = "912200248", Email = "miguel.silva9@mail.com" },
            new Student { IdStudent = 10, IdGrade = 5, FirstName = "Carmen", LastName = "Vega", Phone = "912337779", Email = "carmen.vega10@mail.com" },
            new Student { IdStudent = 11, IdGrade = 1, FirstName = "Jorge", LastName = "Salazar", Phone = "912475310", Email = "jorge.salazar11@mail.com" },
            new Student { IdStudent = 12, IdGrade = 2, FirstName = "Elena", LastName = "Núñez", Phone = "912612841", Email = "elena.nunez12@mail.com" },
            new Student { IdStudent = 13, IdGrade = 3, FirstName = "Diego", LastName = "Quispe", Phone = "912750372", Email = "diego.quispe13@mail.com" },
            new Student { IdStudent = 14, IdGrade = 4, FirstName = "Sofía", LastName = "Herrera", Phone = "912887903", Email = "sofia.herrera14@mail.com" },
            new Student { IdStudent = 15, IdGrade = 5, FirstName = "Andrés", LastName = "Campos", Phone = "913025434", Email = "andres.campos15@mail.com" },
            new Student { IdStudent = 16, IdGrade = 1, FirstName = "Valeria", LastName = "Flores", Phone = "913162965", Email = "valeria.flores16@mail.com" },
            new Student { IdStudent = 17, IdGrade = 2, FirstName = "Raúl", LastName = "Ríos", Phone = "913300496", Email = "raul.rios17@mail.com" },
            new Student { IdStudent = 18, IdGrade = 3, FirstName = "Camila", LastName = "Ortega", Phone = "913438027", Email = "camila.ortega18@mail.com" },
            new Student { IdStudent = 19, IdGrade = 4, FirstName = "Fernando", LastName = "Rojas", Phone = "913575558", Email = "fernando.rojas19@mail.com" },
            new Student { IdStudent = 20, IdGrade = 5, FirstName = "Daniela", LastName = "Cruz", Phone = "913713089", Email = "daniela.cruz20@mail.com" },
            new Student { IdStudent = 21, IdGrade = 1, FirstName = "Ana", LastName = "Vega", Phone = "913850620", Email = "ana.vega21@mail.com" },
            new Student { IdStudent = 22, IdGrade = 2, FirstName = "Luis", LastName = "Salazar", Phone = "913988151", Email = "luis.salazar22@mail.com" },
            new Student { IdStudent = 23, IdGrade = 3, FirstName = "María", LastName = "Núñez", Phone = "914125682", Email = "maria.nunez23@mail.com" },
            new Student { IdStudent = 24, IdGrade = 4, FirstName = "Carlos", LastName = "Quispe", Phone = "914263213", Email = "carlos.quispe24@mail.com" },
            new Student { IdStudent = 25, IdGrade = 5, FirstName = "José", LastName = "Herrera", Phone = "914400744", Email = "jose.herrera25@mail.com" },
            new Student { IdStudent = 26, IdGrade = 1, FirstName = "Lucía", LastName = "Campos", Phone = "914538275", Email = "lucia.campos26@mail.com" },
            new Student { IdStudent = 27, IdGrade = 2, FirstName = "Pedro", LastName = "Flores", Phone = "914675806", Email = "pedro.flores27@mail.com" },
            new Student { IdStudent = 28, IdGrade = 3, FirstName = "Rosa", LastName = "Ríos", Phone = "914813337", Email = "rosa.rios28@mail.com" },
            new Student { IdStudent = 29, IdGrade = 4, FirstName = "Miguel", LastName = "Ortega", Phone = "914950868", Email = "miguel.ortega29@mail.com" },
            new Student { IdStudent = 30, IdGrade = 5, FirstName = "Carmen", LastName = "Rojas", Phone = "915088399", Email = "carmen.rojas30@mail.com" },
            new Student { IdStudent = 31, IdGrade = 1, FirstName = "Jorge", LastName = "Cruz", Phone = "915225930", Email = "jorge.cruz31@mail.com" },
            new Student { IdStudent = 32, IdGrade = 2, FirstName = "Elena", LastName = "Torres", Phone = "915363461", Email = "elena.torres32@mail.com" },
            new Student { IdStudent = 33, IdGrade = 3, FirstName = "Diego", LastName = "Castillo", Phone = "915500992", Email = "diego.castillo33@mail.com" },
            new Student { IdStudent = 34, IdGrade = 4, FirstName = "Sofía", LastName = "Medina", Phone = "915638523", Email = "sofia.medina34@mail.com" },
            new Student { IdStudent = 35, IdGrade = 5, FirstName = "Andrés", LastName = "Ramírez", Phone = "915776054", Email = "andres.ramirez35@mail.com" },
            new Student { IdStudent = 36, IdGrade = 1, FirstName = "Valeria", LastName = "Mendoza", Phone = "915913585", Email = "valeria.mendoza36@mail.com" },
            new Student { IdStudent = 37, IdGrade = 2, FirstName = "Raúl", LastName = "Vargas", Phone = "916051116", Email = "raul.vargas37@mail.com" },
            new Student { IdStudent = 38, IdGrade = 3, FirstName = "Camila", LastName = "Gómez", Phone = "916188647", Email = "camila.gomez38@mail.com" },
            new Student { IdStudent = 39, IdGrade = 4, FirstName = "Fernando", LastName = "Paredes", Phone = "916326178", Email = "fernando.paredes39@mail.com" },
            new Student { IdStudent = 40, IdGrade = 5, FirstName = "Daniela", LastName = "Silva", Phone = "916463709", Email = "daniela.silva40@mail.com" });

        mb.Entity<Enrollment>().HasData(
            new Enrollment { IdEnrollment = 1, IdStudent = 1, IdCourse = 1, Date = new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 2, IdStudent = 1, IdCourse = 4, Date = new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 3, IdStudent = 1, IdCourse = 6, Date = new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 4, IdStudent = 2, IdCourse = 2, Date = new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 5, IdStudent = 2, IdCourse = 5, Date = new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 6, IdStudent = 2, IdCourse = 7, Date = new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 7, IdStudent = 3, IdCourse = 3, Date = new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 8, IdStudent = 3, IdCourse = 6, Date = new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 9, IdStudent = 3, IdCourse = 8, Date = new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 10, IdStudent = 4, IdCourse = 4, Date = new DateTime(2026, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 11, IdStudent = 4, IdCourse = 7, Date = new DateTime(2026, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 12, IdStudent = 4, IdCourse = 1, Date = new DateTime(2026, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 13, IdStudent = 5, IdCourse = 5, Date = new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 14, IdStudent = 5, IdCourse = 8, Date = new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 15, IdStudent = 5, IdCourse = 2, Date = new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 16, IdStudent = 6, IdCourse = 6, Date = new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 17, IdStudent = 6, IdCourse = 1, Date = new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 18, IdStudent = 6, IdCourse = 3, Date = new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 19, IdStudent = 7, IdCourse = 7, Date = new DateTime(2026, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 20, IdStudent = 7, IdCourse = 2, Date = new DateTime(2026, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 21, IdStudent = 7, IdCourse = 4, Date = new DateTime(2026, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 22, IdStudent = 8, IdCourse = 8, Date = new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 23, IdStudent = 8, IdCourse = 3, Date = new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 24, IdStudent = 8, IdCourse = 5, Date = new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 25, IdStudent = 9, IdCourse = 1, Date = new DateTime(2026, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 26, IdStudent = 9, IdCourse = 4, Date = new DateTime(2026, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 27, IdStudent = 9, IdCourse = 6, Date = new DateTime(2026, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 28, IdStudent = 10, IdCourse = 2, Date = new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 29, IdStudent = 10, IdCourse = 5, Date = new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 30, IdStudent = 10, IdCourse = 7, Date = new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 31, IdStudent = 11, IdCourse = 3, Date = new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 32, IdStudent = 11, IdCourse = 6, Date = new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 33, IdStudent = 11, IdCourse = 8, Date = new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 34, IdStudent = 12, IdCourse = 4, Date = new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 35, IdStudent = 12, IdCourse = 7, Date = new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 36, IdStudent = 12, IdCourse = 1, Date = new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 37, IdStudent = 13, IdCourse = 5, Date = new DateTime(2026, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 38, IdStudent = 13, IdCourse = 8, Date = new DateTime(2026, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 39, IdStudent = 13, IdCourse = 2, Date = new DateTime(2026, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 40, IdStudent = 14, IdCourse = 6, Date = new DateTime(2026, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 41, IdStudent = 14, IdCourse = 1, Date = new DateTime(2026, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 42, IdStudent = 14, IdCourse = 3, Date = new DateTime(2026, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 43, IdStudent = 15, IdCourse = 7, Date = new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 44, IdStudent = 15, IdCourse = 2, Date = new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 45, IdStudent = 15, IdCourse = 4, Date = new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 46, IdStudent = 16, IdCourse = 8, Date = new DateTime(2026, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 47, IdStudent = 16, IdCourse = 3, Date = new DateTime(2026, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 48, IdStudent = 16, IdCourse = 5, Date = new DateTime(2026, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 49, IdStudent = 17, IdCourse = 1, Date = new DateTime(2026, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 50, IdStudent = 17, IdCourse = 4, Date = new DateTime(2026, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 51, IdStudent = 17, IdCourse = 6, Date = new DateTime(2026, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 52, IdStudent = 18, IdCourse = 2, Date = new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 53, IdStudent = 18, IdCourse = 5, Date = new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 54, IdStudent = 18, IdCourse = 7, Date = new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 55, IdStudent = 19, IdCourse = 3, Date = new DateTime(2026, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 56, IdStudent = 19, IdCourse = 6, Date = new DateTime(2026, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 57, IdStudent = 19, IdCourse = 8, Date = new DateTime(2026, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 58, IdStudent = 20, IdCourse = 4, Date = new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 59, IdStudent = 20, IdCourse = 7, Date = new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 60, IdStudent = 20, IdCourse = 1, Date = new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 61, IdStudent = 21, IdCourse = 5, Date = new DateTime(2026, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 62, IdStudent = 21, IdCourse = 8, Date = new DateTime(2026, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 63, IdStudent = 21, IdCourse = 2, Date = new DateTime(2026, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 64, IdStudent = 22, IdCourse = 6, Date = new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 65, IdStudent = 22, IdCourse = 1, Date = new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 66, IdStudent = 22, IdCourse = 3, Date = new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 67, IdStudent = 23, IdCourse = 7, Date = new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 68, IdStudent = 23, IdCourse = 2, Date = new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 69, IdStudent = 23, IdCourse = 4, Date = new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 70, IdStudent = 24, IdCourse = 8, Date = new DateTime(2026, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 71, IdStudent = 24, IdCourse = 3, Date = new DateTime(2026, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 72, IdStudent = 24, IdCourse = 5, Date = new DateTime(2026, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 73, IdStudent = 25, IdCourse = 1, Date = new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 74, IdStudent = 25, IdCourse = 4, Date = new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 75, IdStudent = 25, IdCourse = 6, Date = new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 76, IdStudent = 26, IdCourse = 2, Date = new DateTime(2026, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 77, IdStudent = 26, IdCourse = 5, Date = new DateTime(2026, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 78, IdStudent = 26, IdCourse = 7, Date = new DateTime(2026, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 79, IdStudent = 27, IdCourse = 3, Date = new DateTime(2026, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 80, IdStudent = 27, IdCourse = 6, Date = new DateTime(2026, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 81, IdStudent = 27, IdCourse = 8, Date = new DateTime(2026, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 82, IdStudent = 28, IdCourse = 4, Date = new DateTime(2026, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 83, IdStudent = 28, IdCourse = 7, Date = new DateTime(2026, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 84, IdStudent = 28, IdCourse = 1, Date = new DateTime(2026, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 85, IdStudent = 29, IdCourse = 5, Date = new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 86, IdStudent = 29, IdCourse = 8, Date = new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 87, IdStudent = 29, IdCourse = 2, Date = new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 88, IdStudent = 30, IdCourse = 6, Date = new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 89, IdStudent = 30, IdCourse = 1, Date = new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 90, IdStudent = 30, IdCourse = 3, Date = new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 91, IdStudent = 31, IdCourse = 7, Date = new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 92, IdStudent = 31, IdCourse = 2, Date = new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 93, IdStudent = 31, IdCourse = 4, Date = new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 94, IdStudent = 32, IdCourse = 8, Date = new DateTime(2026, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 95, IdStudent = 32, IdCourse = 3, Date = new DateTime(2026, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 96, IdStudent = 32, IdCourse = 5, Date = new DateTime(2026, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 97, IdStudent = 33, IdCourse = 1, Date = new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 98, IdStudent = 33, IdCourse = 4, Date = new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 99, IdStudent = 33, IdCourse = 6, Date = new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 100, IdStudent = 34, IdCourse = 2, Date = new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 101, IdStudent = 34, IdCourse = 5, Date = new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 102, IdStudent = 34, IdCourse = 7, Date = new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 103, IdStudent = 35, IdCourse = 3, Date = new DateTime(2026, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 104, IdStudent = 35, IdCourse = 6, Date = new DateTime(2026, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 105, IdStudent = 35, IdCourse = 8, Date = new DateTime(2026, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 106, IdStudent = 36, IdCourse = 4, Date = new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 107, IdStudent = 36, IdCourse = 7, Date = new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 108, IdStudent = 36, IdCourse = 1, Date = new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 109, IdStudent = 37, IdCourse = 5, Date = new DateTime(2026, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 110, IdStudent = 37, IdCourse = 8, Date = new DateTime(2026, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 111, IdStudent = 37, IdCourse = 2, Date = new DateTime(2026, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 112, IdStudent = 38, IdCourse = 6, Date = new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 113, IdStudent = 38, IdCourse = 1, Date = new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 114, IdStudent = 38, IdCourse = 3, Date = new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 115, IdStudent = 39, IdCourse = 7, Date = new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 116, IdStudent = 39, IdCourse = 2, Date = new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 117, IdStudent = 39, IdCourse = 4, Date = new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 118, IdStudent = 40, IdCourse = 8, Date = new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 119, IdStudent = 40, IdCourse = 3, Date = new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
            new Enrollment { IdEnrollment = 120, IdStudent = 40, IdCourse = 5, Date = new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });
    }
}
