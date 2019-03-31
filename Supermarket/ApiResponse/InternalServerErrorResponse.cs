using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace Supermarket.ApiResponse
{
    public class InternalServerErrorResponse : ValidationProblemDetails
    {
        public Guid TraceId { get; set; }

        public InternalServerErrorResponse(string error) : base(new Dictionary<string, string[]> { { "error", new[] { error } } })
        {
            TraceId = Guid.NewGuid();
            Title = HttpStatusCode.InternalServerError.ToString();
            Status = (int)HttpStatusCode.InternalServerError;
        }
    }
}
