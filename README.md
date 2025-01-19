# Quiz Application (Full Stack)

A full stack quiz application that utilises ASP.NET Web API for backend and React/TypeScript for the front end. Once user opens/enters application, supplies name and email and begins to take quiz. After the final answer result is shown and participation is sent to backend, database. User then can view Leaderboard of TOP 10 participators or beign to take quiz again. Questions inside the quiz have their own set of points that can be set individually (in current case all are worth 100 points), single selection and typed answers must be correct answered to get all the points while multiple selection option ones are calculated under a formula: `(QustionPoints / CorrectSetAnswerCount) * CorrectUserSelectedCount`. Penalty is applied if more than needed answers are selected by removing points.

## Roadmap

1. ~~Serilog (Logging) implementation to backend~~ (Finished: [PR#7](https://github.com/Emcrowz/QuizApplication/pull/7))
2. Indepth unit testing for backend
3. Frontend unit tests
4. ~~Bug and known issue fixes~~ (Finished: [PR#8](https://github.com/Emcrowz/QuizApplication/pull/8))
5. Design implementation
6. Docker containerization

## Tech Stack

**Client:** React, TypeScript, TailwindCSS

**Server:** ASP.NET Core Web API (With Controllers)

**Backend:** C#12/.NET8, EntityFramework Core, SQLite/InMemory

**NPM Packages:** react-router-dom, axios, tailwindcss

**NuGet Packages:** EntityFrameworkCore, EntityFrameworkCore.Design, EntityFrameworkCore.Tools, EntityFrameworkCore.Sqlite, Microsoft.EntityFrameworkCore.InMemory, Microsoft.AspNetCore.SpaPoxy, Moq, xunit, Swashbuckle.AspNetCore (Swagger), Serilog.AspNetCore, Serilog.Sinks.Console, Serilog.Sinks.File

## Prerequisites
1. .NET SDK 8.404 or higher | Can be downloaded here: [.NET SDK 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
2. NodeJS v22.13.0 or higher | Can be downloaded here: [NodeJS](https://nodejs.org/en/download)
3. NPM 10.8.2 or higher | Included with NodeJS download.

## Global project launch
It is possible to start the project using a bash script that is found inside the root project folder, named: `ProjectStart.sh`. 

Using bash type and press enter:
```bash
bash ProjectStart.sh
```
When the script is launched you can press [X] to terminate all of the running background nodejs and dotnet processes thus finishing work of both frontend and backend application execution.

## Project launch by layers
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

## Technical project information
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

## Optional configurations
### LocalDb.db file linking to use SQLite instead of InMemory database
By default since [PR#7](https://github.com/Emcrowz/QuizApplication/pull/7) default DB is used as InMemory for testing and showcase purposes. To use SQLite one line of code needs to be changed inside `QuizApplication.Server\Program.cs` file:
```
builder.Services.AddDbContext<QuizDbContext>(options => options.UseInMemoryDatabase(ConstantValues.InMemory));
```

needs to be changed to:

```
builder.Services.AddDbContext<QuizDbContext>(options => options.UseSqlite(config.GetConnectionString(ConstantValues.DefaultConnection)));
```

and inside `appsettings.Development.json` or `appsettings.json` replace [PATH] to the location of the file. File is found inside `QuizApplication.DataAccess` project. 
```
"ConnectionStrings": {
  "SQLite": "Data Source=[PATH]LocalDb.db"
}
```
> [!NOTE]
> System path was used so that file wouldn't appear inside bin/obj folders and be in more reachable location. __There is no valuable or sensitive data inside and can be used for development/testing purposes.__ Additional file `CleanDb.db` is supplied as a clean-slate db file. Location is the same.

## Potential issues and workarounds
### Frontend doesn't fetch data
This could be the issue regarding security sertificates for the backend. If backend is used with HTTPS (Secure) then port `7129` is used otherwise - for HTTP `5170`. Then what needs to be changed is the port inside `AxiosInstance.ts` file found inside the `quizapplication.client\src\Config` folder. Change port to according protocol used.

## Authors

- Martynas Vrubliauskas [@emcrowz](https://www.github.com/emcrowz)

Project last updated: 2025-01-19
