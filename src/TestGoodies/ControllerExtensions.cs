using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TestGoodies
{
    public static class ControllerExtensions
    {
        public static DefaultHttpContext MockHttpContext(this ControllerBase controller, string scheme, string host, int? port = null, IDictionary<string, string>? header = null)
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Scheme = scheme;
            httpContext.Request.Host = new HostString(host, port ?? 80);

            if (header != null)
            {
                foreach (var key in header?.Keys)
                    httpContext.Request.Headers.Add(key, header[key]);
            }

            controller.ControllerContext = new ControllerContext { HttpContext = httpContext };
            return httpContext;
        }
    }
}