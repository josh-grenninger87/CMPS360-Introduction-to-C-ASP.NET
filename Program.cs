
using StudentCourseApi.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();

// Create a list of five courses
var courses = new List<Course>
{
    new Course { Id = 1, Code = "CMPS360", Title = "Java Programming", Credits = 3, Instructor = "Professor Tarantino" },
    new Course { Id = 2, Code = "CMPS363", Title = "Cybersecurity", Credits = 3, Instructor = "Professor Friedkin" },
    new Course { Id = 3, Code = "CMPS460", Title = "Web Application Development", Credits = 3, Instructor = "Professor Altman" },
    new Course { Id = 4, Code = "CMPS480", Title = "Business Analytics", Credits = 3, Instructor = "Professor Anderson" },
    new Course { Id = 5, Code = "CMPS350", Title = "Computer Networking", Credits = 3, Instructor = "Professor Gunn" }
};

// GET all courses
app.MapGet("/api/courses", () =>
{
    return Results.Ok(courses);
});

// GET a course by ID
app.MapGet("/api/courses/{id:int}", (int id) =>
{
    var course = courses.FirstOrDefault(c => c.Id == id);

    if (course == null)
        return Results.NotFound();

    return Results.Ok(course);
});

// POST a new course
app.MapPost("/api/courses", (Course course) =>
{
    if (!IsValidCourse(course))
        return Results.BadRequest("Invalid course information.");

    course.Id = courses.Max(c => c.Id) + 1;
    courses.Add(course);

    return Results.Created($"/api/courses/{course.Id}", course);
});

// PUT update an existing course
app.MapPut("/api/courses/{id:int}", (int id, Course updatedCourse) =>
{
    var course = courses.FirstOrDefault(c => c.Id == id);

    if (course == null)
        return Results.NotFound();

    if (!IsValidCourse(updatedCourse))
        return Results.BadRequest("Invalid course information.");

    course.Code = updatedCourse.Code;
    course.Title = updatedCourse.Title;
    course.Credits = updatedCourse.Credits;
    course.Instructor = updatedCourse.Instructor;

    return Results.Ok(course);
});

// DELETE a course
app.MapDelete("/api/courses/{id:int}", (int id) =>
{
    var course = courses.FirstOrDefault(c => c.Id == id);

    if (course == null)
        return Results.NotFound();

    courses.Remove(course);

    return Results.NoContent();
});

app.Run();

// Validate course information
static bool IsValidCourse(Course course)
{
    return !string.IsNullOrWhiteSpace(course.Code)
        && !string.IsNullOrWhiteSpace(course.Title)
        && !string.IsNullOrWhiteSpace(course.Instructor)
        && course.Credits >= 1
        && course.Credits <= 6;
}
