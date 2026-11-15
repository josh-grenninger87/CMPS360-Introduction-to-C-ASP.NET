# CMPS 360 Assignment 4

## Description

This assignment we were to create a Student Course API using C# and ASP.NET Core. The program stores a list of courses and allows users to view, add, update, and delete courses.

Each course contains an ID, course code, title, number of credits, and instructor.


## Programs and Tools Used

- Visual Studio Code
- C#
- ASP.NET Core
- .NET 10
- HTML and JavaScript
- PowerShell
- Google Chrome

## How to Run the Program

1. Open the `StudentCourseApi` folder in Visual Studio Code.
2. Open the terminal.
3. Make sure .NET is installed by typing `dotnet --version`.
4. Type `dotnet run` to start the program.
5. Open Google Chrome and go to `http://localhost:5173`.


## API Commands

The program uses the following commands to manage courses.

| Command | API Address | Description |
|---|---|---|
| GET | `/api/courses` | Displays all courses |
| GET | `/api/courses/{id}` | Displays a course by its ID |
| POST | `/api/courses` | Adds a new course |
| PUT | `/api/courses/{id}` | Updates an existing course |
| DELETE | `/api/courses/{id}` | Deletes a course |

The program also checks that the course code, title, and instructor are not blank and that the number of credits is between 1 and 6.

## Example Course Information

The following is an example of the information used to add a course.

```json
{
  "code": "CMPS370",
  "title": "Database Management",
  "credits": 3,
  "instructor": "Professor Scorsese"
}
```

## Webpage

I created a simple HTML webpage that uses JavaScript to retrieve course information from the API.

The webpage displays the following information in a table:

- Course Code
- Course Title
- Credits

JavaScript uses `fetch()` to retrieve the courses from the API and display them on the webpage.

## Additional Information

The courses are stored in memory rather than in a database. This means that any courses added, updated, or deleted will reset when the program is restarted.
