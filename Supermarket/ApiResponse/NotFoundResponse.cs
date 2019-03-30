using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace Supermarket.ApiResponse
{
    public class NotFoundResponse : ValidationProblemDetails
    {
        public Guid TraceId { get; set; }

        public NotFoundResponse(string error) : base(new Dictionary<string, string[]> { { "error", new[] { error } } })
        {
            TraceId = Guid.NewGuid();
            Title = HttpStatusCode.NotFound.ToString();
            Status = (int)HttpStatusCode.NotFound;
        }

        ////In feature, to log the not found response
        //public NotFoundResponse(string error, ILogger logger) : base(new Dictionary<string, string[]> { { "error", new[] { error } } })
        //{
        //    TraceId = Guid.NewGuid();
        //    Title = HttpStatusCode.NotFound.ToString();
        //    Status = (int)HttpStatusCode.NotFound;
        //    logger.LogInformation(JsonConvert.SerializeObject(this,
        //                                                       Formatting.Indented,
        //                                                       new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }
        //                                                      ));
        //}
    }
}
