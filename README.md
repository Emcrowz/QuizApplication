# Quiz Application (Full Stack)

A full stack quiz application that utilises ASP.NET Web API for backend and React/TypeScript for the front end. Once user opens/enters application, supplies name and email and begins to take quiz. After the final answer result is shown and participation is sent to backend, database. User then can view Leaderboard of TOP 10 participators and beign to take quiz again.



## Tech Stack

**Client:** React, TypeScript, TailwindCSS

**Server:** ASP.NET Core Web API (With Controllers)

**Backend:** C#12/.NET8, EntityFramework Core, SQLite

**NPM Packages:** react-router-dom, tailwindcss

**NuGet Packages:** EntityFrameworkCore, EntityFrameworkCore.Design, EntityFrameworkCore.Tools, EntityFrameworkCore.Sqlite, Microsoft.AspNetCore.SpaPoxy, Moq, xunit, Swashbuckle.AspNetCore (Swagger)

## Installation

> [!WARNING]
> One of the manual configurations is the PATH to the SQLite db file. Database file is provided with the project. However on different systems needs to be manually linked inside APPSETTINGS.DEVELOPMENT.JSON or APPSETTINGS.JSON file.

### Frontend React/TypeScript

```bash
  cd quizapplication.client
  npm install
  npm run dev
```

### Backend ASP.NET Core Web API

```bash
  cd QuizApplication.Server
  dotnet build
  dotnet run
```

### HTTP and HTTPS endpoints
Frontend endpoints are as follows:
- https://localhost:64905/                  Root path. Login, Quiz and Score displayed here
- https://localhost:64905/leaderboard       Leaderboard path. Here is displayed TOP 10 quiz participants
- https://localhost:64905/*                 Any other path will return NotFound or Error pages.

API endpoints are as follows

HTTP Backend:
- http://localhost:5170/questions/getall        [GET]   returns: IEnumerable<QuestionReadOnlyDto>
- http://localhost:5170/participants/getall     [GET]   returns: IEnumerable<ParticipantReadOnlyDto>
- http://localhost:5170/questions/postsingle    [POST]  returns: int; takes: ParticipantPostDto
- http://localhost:5170/questions/gettop        [GET]   return: IEnumerable<ParticipantReadOnlyDto>

HTTPS Backend:
- Instead of `5170` - use `7219`. Enpoints are the same.

## Troubleshooting
### LocalDb.db file linking in the backend

Inside `appsettings.Development.json` or `appsettings.json` replace [PATH] to the location of the file. File is found inside `QuizApplication.DataAccess` project. 
```
"ConnectionStrings": {
  "SQLite": "Data Source=[PATH]LocalDb.db"
}
```
Note: System path was used so that file wouldn't appear inside bin/obj folders and be in more reachable location. __There is no valuable or sensitive data inside and can be used for development/testing purposes.__

## Authors

- Martynas Vrubliauskas [@emcrowz](https://www.github.com/emcrowz)

Project last updated: 2025-01-15