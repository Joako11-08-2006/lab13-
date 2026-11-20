using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laboratorio13.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    IdCourse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Credit = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.IdCourse);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    IdGrade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.IdGrade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    IdStudent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGrade = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.IdStudent);
                    table.ForeignKey(
                        name: "FK_Students_Grades_IdGrade",
                        column: x => x.IdGrade,
                        principalTable: "Grades",
                        principalColumn: "IdGrade",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    IdEnrollment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdStudent = table.Column<int>(type: "int", nullable: false),
                    IdCourse = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.IdEnrollment);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_IdCourse",
                        column: x => x.IdCourse,
                        principalTable: "Courses",
                        principalColumn: "IdCourse",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_IdStudent",
                        column: x => x.IdStudent,
                        principalTable: "Students",
                        principalColumn: "IdStudent",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "IdCourse", "Credit", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, 4, false, "Matemática" },
                    { 2, 3, false, "Comunicación" },
                    { 3, 2, false, "Historia" },
                    { 4, 4, false, "Ciencias" },
                    { 5, 3, false, "Inglés" },
                    { 6, 2, false, "Arte" },
                    { 7, 2, false, "Educación Física" },
                    { 8, 3, false, "Computación" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "IdGrade", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "Primer grado", false, "Primero" },
                    { 2, "Segundo grado", false, "Segundo" },
                    { 3, "Tercer grado", false, "Tercero" },
                    { 4, "Cuarto grado", false, "Cuarto" },
                    { 5, "Quinto grado", false, "Quinto" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "IdStudent", "Email", "FirstName", "IdGrade", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "ana.torres1@mail.com", "Ana", 1, "Torres", "911100000" },
                    { 2, "luis.castillo2@mail.com", "Luis", 2, "Castillo", "911237531" },
                    { 3, "maria.medina3@mail.com", "María", 3, "Medina", "911375062" },
                    { 4, "carlos.ramirez4@mail.com", "Carlos", 4, "Ramírez", "911512593" },
                    { 5, "jose.mendoza5@mail.com", "José", 5, "Mendoza", "911650124" },
                    { 6, "lucia.vargas6@mail.com", "Lucía", 1, "Vargas", "911787655" },
                    { 7, "pedro.gomez7@mail.com", "Pedro", 2, "Gómez", "911925186" },
                    { 8, "rosa.paredes8@mail.com", "Rosa", 3, "Paredes", "912062717" },
                    { 9, "miguel.silva9@mail.com", "Miguel", 4, "Silva", "912200248" },
                    { 10, "carmen.vega10@mail.com", "Carmen", 5, "Vega", "912337779" },
                    { 11, "jorge.salazar11@mail.com", "Jorge", 1, "Salazar", "912475310" },
                    { 12, "elena.nunez12@mail.com", "Elena", 2, "Núñez", "912612841" },
                    { 13, "diego.quispe13@mail.com", "Diego", 3, "Quispe", "912750372" },
                    { 14, "sofia.herrera14@mail.com", "Sofía", 4, "Herrera", "912887903" },
                    { 15, "andres.campos15@mail.com", "Andrés", 5, "Campos", "913025434" },
                    { 16, "valeria.flores16@mail.com", "Valeria", 1, "Flores", "913162965" },
                    { 17, "raul.rios17@mail.com", "Raúl", 2, "Ríos", "913300496" },
                    { 18, "camila.ortega18@mail.com", "Camila", 3, "Ortega", "913438027" },
                    { 19, "fernando.rojas19@mail.com", "Fernando", 4, "Rojas", "913575558" },
                    { 20, "daniela.cruz20@mail.com", "Daniela", 5, "Cruz", "913713089" },
                    { 21, "ana.vega21@mail.com", "Ana", 1, "Vega", "913850620" },
                    { 22, "luis.salazar22@mail.com", "Luis", 2, "Salazar", "913988151" },
                    { 23, "maria.nunez23@mail.com", "María", 3, "Núñez", "914125682" },
                    { 24, "carlos.quispe24@mail.com", "Carlos", 4, "Quispe", "914263213" },
                    { 25, "jose.herrera25@mail.com", "José", 5, "Herrera", "914400744" },
                    { 26, "lucia.campos26@mail.com", "Lucía", 1, "Campos", "914538275" },
                    { 27, "pedro.flores27@mail.com", "Pedro", 2, "Flores", "914675806" },
                    { 28, "rosa.rios28@mail.com", "Rosa", 3, "Ríos", "914813337" },
                    { 29, "miguel.ortega29@mail.com", "Miguel", 4, "Ortega", "914950868" },
                    { 30, "carmen.rojas30@mail.com", "Carmen", 5, "Rojas", "915088399" },
                    { 31, "jorge.cruz31@mail.com", "Jorge", 1, "Cruz", "915225930" },
                    { 32, "elena.torres32@mail.com", "Elena", 2, "Torres", "915363461" },
                    { 33, "diego.castillo33@mail.com", "Diego", 3, "Castillo", "915500992" },
                    { 34, "sofia.medina34@mail.com", "Sofía", 4, "Medina", "915638523" },
                    { 35, "andres.ramirez35@mail.com", "Andrés", 5, "Ramírez", "915776054" },
                    { 36, "valeria.mendoza36@mail.com", "Valeria", 1, "Mendoza", "915913585" },
                    { 37, "raul.vargas37@mail.com", "Raúl", 2, "Vargas", "916051116" },
                    { 38, "camila.gomez38@mail.com", "Camila", 3, "Gómez", "916188647" },
                    { 39, "fernando.paredes39@mail.com", "Fernando", 4, "Paredes", "916326178" },
                    { 40, "daniela.silva40@mail.com", "Daniela", 5, "Silva", "916463709" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "IdEnrollment", "Date", "IdCourse", "IdStudent" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 3, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1 },
                    { 4, new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 5, new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2 },
                    { 6, new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 2 },
                    { 7, new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 8, new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 3 },
                    { 9, new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 3 },
                    { 10, new DateTime(2026, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4 },
                    { 11, new DateTime(2026, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 4 },
                    { 12, new DateTime(2026, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 13, new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5 },
                    { 14, new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 5 },
                    { 15, new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5 },
                    { 16, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 6 },
                    { 17, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 6 },
                    { 18, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 6 },
                    { 19, new DateTime(2026, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 7 },
                    { 20, new DateTime(2026, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 7 },
                    { 21, new DateTime(2026, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 7 },
                    { 22, new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 8 },
                    { 23, new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 8 },
                    { 24, new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 8 },
                    { 25, new DateTime(2026, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 9 },
                    { 26, new DateTime(2026, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 9 },
                    { 27, new DateTime(2026, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 9 },
                    { 28, new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 10 },
                    { 29, new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 10 },
                    { 30, new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 10 },
                    { 31, new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 11 },
                    { 32, new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 11 },
                    { 33, new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 11 },
                    { 34, new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 12 },
                    { 35, new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 12 },
                    { 36, new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 12 },
                    { 37, new DateTime(2026, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 13 },
                    { 38, new DateTime(2026, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 13 },
                    { 39, new DateTime(2026, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 13 },
                    { 40, new DateTime(2026, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 14 },
                    { 41, new DateTime(2026, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 14 },
                    { 42, new DateTime(2026, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 14 },
                    { 43, new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 15 },
                    { 44, new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 15 },
                    { 45, new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 15 },
                    { 46, new DateTime(2026, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 16 },
                    { 47, new DateTime(2026, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 16 },
                    { 48, new DateTime(2026, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 16 },
                    { 49, new DateTime(2026, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 17 },
                    { 50, new DateTime(2026, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 17 },
                    { 51, new DateTime(2026, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 17 },
                    { 52, new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 18 },
                    { 53, new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 18 },
                    { 54, new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 18 },
                    { 55, new DateTime(2026, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 19 },
                    { 56, new DateTime(2026, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 19 },
                    { 57, new DateTime(2026, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 19 },
                    { 58, new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 20 },
                    { 59, new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 20 },
                    { 60, new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 20 },
                    { 61, new DateTime(2026, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 21 },
                    { 62, new DateTime(2026, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 21 },
                    { 63, new DateTime(2026, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 21 },
                    { 64, new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 22 },
                    { 65, new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 22 },
                    { 66, new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 22 },
                    { 67, new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 23 },
                    { 68, new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 23 },
                    { 69, new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 23 },
                    { 70, new DateTime(2026, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 24 },
                    { 71, new DateTime(2026, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 24 },
                    { 72, new DateTime(2026, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 24 },
                    { 73, new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 25 },
                    { 74, new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 25 },
                    { 75, new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 25 },
                    { 76, new DateTime(2026, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 26 },
                    { 77, new DateTime(2026, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 26 },
                    { 78, new DateTime(2026, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 26 },
                    { 79, new DateTime(2026, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 27 },
                    { 80, new DateTime(2026, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 27 },
                    { 81, new DateTime(2026, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 27 },
                    { 82, new DateTime(2026, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 28 },
                    { 83, new DateTime(2026, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 28 },
                    { 84, new DateTime(2026, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 28 },
                    { 85, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 29 },
                    { 86, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 29 },
                    { 87, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 29 },
                    { 88, new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 30 },
                    { 89, new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 30 },
                    { 90, new DateTime(2026, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 30 },
                    { 91, new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 31 },
                    { 92, new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 31 },
                    { 93, new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 31 },
                    { 94, new DateTime(2026, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 32 },
                    { 95, new DateTime(2026, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 32 },
                    { 96, new DateTime(2026, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 32 },
                    { 97, new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 33 },
                    { 98, new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 33 },
                    { 99, new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 33 },
                    { 100, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 34 },
                    { 101, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 34 },
                    { 102, new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 34 },
                    { 103, new DateTime(2026, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 35 },
                    { 104, new DateTime(2026, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 35 },
                    { 105, new DateTime(2026, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 35 },
                    { 106, new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 36 },
                    { 107, new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 36 },
                    { 108, new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 36 },
                    { 109, new DateTime(2026, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 37 },
                    { 110, new DateTime(2026, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 37 },
                    { 111, new DateTime(2026, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 37 },
                    { 112, new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 38 },
                    { 113, new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 38 },
                    { 114, new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 38 },
                    { 115, new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 39 },
                    { 116, new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 39 },
                    { 117, new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 39 },
                    { 118, new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 40 },
                    { 119, new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 40 },
                    { 120, new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 40 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_IdCourse",
                table: "Enrollments",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_IdStudent",
                table: "Enrollments",
                column: "IdStudent");

            migrationBuilder.CreateIndex(
                name: "IX_Students_IdGrade",
                table: "Students",
                column: "IdGrade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Enrollments");
            migrationBuilder.DropTable(name: "Courses");
            migrationBuilder.DropTable(name: "Students");
            migrationBuilder.DropTable(name: "Grades");
        }
    }
}
