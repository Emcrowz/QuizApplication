# Quiz Application (Full Stack)

A full stack quiz application that utilises ASP.NET Web API for backend and React/TypeScript for the front end. Once user opens/enters application, supplies name and email and begins to take quiz. After the final answer result is shown and participation is sent to backend, database. User then can view Leaderboard of TOP 10 participators or beign to take quiz again. Questions inside the quiz have their own set of points that can be set individually (in current case all are worth 100 points), single selection and typed answers must be correct answered to get all the points while multiple selection option ones are calculated under a formula: `(QustionPoints / CorrectSetAnswerCount) * CorrectUserSelectedCount`. Penalty is applied if more than needed answers are selected by removing points.

## Roadmap

1. Serilog (Logging) implementation to backend
2. Indepth unit testing for backend
3. Frontend unit tests
4. Bug and known issue fixes
5. Design implementation
6. Docker containerization

## Tech Stack

**Client:** React, TypeScript, TailwindCSS

**Server:** ASP.NET Core Web API (With Controllers)

**Backend:** C#12/.NET8, EntityFramework Core, SQLite

**NPM Packages:** react-router-dom, axios, tailwindcss

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
**Frontend** endpoints are as follows:
| Endpoint | Description |
| ---------------- | ------------------------------------------------ |
| localhost:64905/ | Root path. Login, Quiz and Score displayed herex |
| localhost:64905/leaderboard | Leaderboard path. Here is displayed TOP 10 quiz participants. |
| localhost:64905/* | Any other path will return NotFound or Error pages. |

**API** endpoints are as follows

HTTP Backend:
| Endpoint | Request | Returns/Takes |
| ---------------------------------- | ----- |--------------------------------------------- |
| localhost:5170/participants/getall | [GET] | returns: IEnumerable<ParticipantReadOnlyDto> |
| localhost:5170/participants/postsingle | [POST] | returns: int FinalScore; takes: ParticipantPostDto |
| localhost:5170/questions/gettop | [GET] | return: IEnumerable<QuestionReadOnlyDto> |

HTTPS Backend:
- Instead of `5170` - `7219` is being used with HTTPS. Enpoints are the same.

## Troubleshooting and potential issues
### LocalDb.db file linking in the backend

Inside `appsettings.Development.json` or `appsettings.json` replace [PATH] to the location of the file. File is found inside `QuizApplication.DataAccess` project. 
```
"ConnectionStrings": {
  "SQLite": "Data Source=[PATH]LocalDb.db"
}
```
> [!NOTE]
> System path was used so that file wouldn't appear inside bin/obj folders and be in more reachable location. __There is no valuable or sensitive data inside and can be used for development/testing purposes.__ Additional file `CleanDb.db` is supplied as a clean-slate db file. Location is the same.

### Frontend doesn't fetch data
This could be the issue regarding security sertificates for the backend. If backend is used with HTTPS (Secure) then port `7129` is used otherwise - for HTTP `5170`. Then what needs to be changed is the port inside `AxiosInstance.ts` file found inside the `quizapplication.client\src\Config` folder. Change port to according protocol used.

### Score is submitted two times from one call
After the quiz is over and finalized - POST request is sent two times instead of one so it creates a duplicated record inside db.

*Known issue. Will be addressed and changed in the future commits/pull-requests.*

## Authors

- Martynas Vrubliauskas [@emcrowz](https://www.github.com/emcrowz)

Project last updated: 2025-01-15
