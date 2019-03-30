using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace Supermarket.ApiResponse
{
    public class BadRequestResponse : ValidationProblemDetails
    {
        public Guid TraceId { get; set; }

        public BadRequestResponse(string error) : base(new Dictionary<string, string[]> { { "error", new[] { error } } })
        {
            TraceId = Guid.NewGuid();
            Title = HttpStatusCode.BadRequest.ToString();
            Status = (int)HttpStatusCode.BadRequest;
        }
    }
}
