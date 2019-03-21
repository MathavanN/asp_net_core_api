using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Supermarket.Swagger
{
    public static class SwaggerInfo
    {
        public static Info CreateInfoForApiVersion(ApiVersionDescription description, Type type)
        {
            var info = new Info()
            {
                Title = $"{type.Assembly.GetCustomAttribute<AssemblyProductAttribute>().Product} {description.ApiVersion}",
                Version = description.ApiVersion.ToString(),
                Description = "Supermarket ASP.NET Core Web API",
                TermsOfService = "None",
                Contact = new Contact { Name = "Mathavan N", Email = "mathavan@gmail.com", Url = "https://github.com/Mathavana" },
                License = new License { Name = "Use under LICX", Url = "https://example.com/license" }
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }
}
