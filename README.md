# Laboratorio 13 - Code First (ASP.NET Core 8 + EF Core)

## Opción A: base de datos en memoria (por defecto, no instala nada)
```
dotnet restore
dotnet run
```
Abrir http://localhost:5000 (o el puerto que muestre la consola).

## Opción B: SQL Server con autenticación de Windows (migraciones reales)
1. Instalar **SQL Server Express** (gratis) y dejar la instancia `SQLEXPRESS`.
2. En `appsettings.json` cambiar `"UseInMemoryDatabase": true` a `false`.
3. En la terminal:
```
dotnet tool install --global dotnet-ef
dotnet ef database update
dotnet run
```
La migración `InitialCreate` ya está en la carpeta `Migrations` y crea las 4 tablas con sus llaves foráneas y datos de ejemplo.

## Endpoints
- /Grades y /Courses : CRUD con eliminación lógica (IsDeleted)
- /api/students/search?firstName=&lastName=&email=
- /api/students/by-name-grade?firstName=&grade=
- /api/enrollments/by-course?course=
- /api/enrollments/by-grade?grade=

## Git
```
git init
git add .
git commit -m "feat: Code First, CRUD Grade/Course con eliminacion logica y endpoints"
git branch -M main
git remote add origin <URL_DEL_REPO>
git push -u origin main
```
