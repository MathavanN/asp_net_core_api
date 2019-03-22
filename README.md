# ASP.NET Core Web API development

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

### Next ToDo List:
- Role Based Authentication/Authorization
- Standard response for both error/success results
- Global Error Handling
- Dockerization

### Note
- Trying to understand best practices. May be frequently modified the project structure.
- ASP NET Identity: Using EF core code first approach

### Reference From
- See [chsakell](https://chsakell.com)
- See [code-maze](https://code-maze.com)
- See [CodAffection](https://www.youtube.com/channel/UCvzlnZbePin9kH-1JCKBt8Q)

License
----

MIT


**Free Software, Hell Yeah!**
