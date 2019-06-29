using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace Supermarket.ApiResponse
{
    public class ForbiddenResponse : ValidationProblemDetails
    {
        public Guid TraceId { get; set; }

        public ForbiddenResponse(string error) : base(new Dictionary<string, string[]> { { "error", new[] { error } } })
        {
            TraceId = Guid.NewGuid();
            Title = HttpStatusCode.Forbidden.ToString();
            Status = (int)HttpStatusCode.Forbidden;
        }
    }
}
