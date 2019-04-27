# ASP.NET Core Web API development

[![CircleCI](https://circleci.com/gh/Mathavana/asp_net_core_api/tree/master.svg?style=svg)](https://circleci.com/gh/Mathavana/asp_net_core_api/tree/master) | [![codecov](https://codecov.io/gh/Mathavana/asp_net_core_api/branch/develop/graph/badge.svg)](https://codecov.io/gh/Mathavana/asp_net_core_api) |

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
- CircleCi
- Standard response for error (400,404, 500) results (Similar to ApiController model validation result)
- Global Error Handling
- Updated CircleCi for code coverage report
- Local Codecoverage report generation bat file added inside unit test project

### Next ToDo List:
- Role Based Authentication/Authorization
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

[![](https://codescene.io/projects/4502/status.svg) Get more details at **codescene.io**.](https://codescene.io/projects/4502/jobs/latest-successful/results)

License
----

MIT


**Free Software, Hell Yeah!**
