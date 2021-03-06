# ASP.NET Core Web API development

![.NET Core](https://github.com/MathavanN/asp_net_core_api/workflows/.NET%20Core/badge.svg)

We will try to create an API application using asp.net core.
- Mainly using repository pattern, generics, LINQ, Entity framework core
- Main business logic implemented in InMemeory Database (plan to use MSSQL DB)
- ASP NET Identity, JWT Authentication implemented in a separate DB
- Swagger for API Document
- API Version
- Logging (Serilog)
- API Analyzer added - For proper swagger documentation
- Model.IsValid is removed in each controller. (ApiController auto implement Model.IsValid)
- Models, Enums, Context, Repositories moved to Supermarket.Core project
- xUnit Test Project added
- ~~CircleCi~~
- Standard response for error (400, 403, 404, 500) results (Similar to ApiController model validation result)
- Global Error Handling
- Updated CircleCi for code coverage report
- Local Codecoverage report generation bat file added inside unit test project
- ~~Role Based Authentication/Authorization~~ Policy Based Authorization
- Github Actions for CICD pipeline

### Next ToDo List:
- Migrate .NET Core 3.1
- Dockerization
- More test cases needed
- Proper model implementation
- model to DB


### Note
- Trying to understand best practices. May be frequently modified the project structure.
- ASP NET Identity: Using EF core code first approach

### Reference From
- See [chsakell](https://chsakell.com)
- See [code-maze](https://code-maze.com)
- See [CodAffection](https://www.youtube.com/channel/UCvzlnZbePin9kH-1JCKBt8Q)
- See [MSDN](https://msdn.microsoft.com/en-us/magazine/mt826337.aspx)

[![](https://codescene.io/projects/4502/status.svg) Get more details at **codescene.io**.](https://codescene.io/projects/4502/jobs/latest-successful/results)

License
----

MIT


**Free Software, Hell Yeah!**
