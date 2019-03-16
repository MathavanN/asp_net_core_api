using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.Domain.Services;
using Supermarket.Domain.Services.Contracts;
using Supermarket.Persistent.Context;
using Supermarket.Persistent.Contracts;
using Supermarket.Persistent.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace Supermarket.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options => { });
        }

        public static void ConfigureMSSQLContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseInMemoryDatabase("supermarket-api-in-memory");
            });
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureServicesWrapper(this IServiceCollection services)
        {
            services.AddScoped<IServiceWrapper, ServiceWrapper>();
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Supermarket API",
                    Version = "v1",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Mathavan N",
                        Email = "mathavan@gmail.com",
                        Url = "https://github.com/Mathavana"
                    },
                    License = new License
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    }
                });
            });
        }
    }
}
