using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace middleware.Infrastructures
{
    public class CheckForIPAddress
    {
        private RequestDelegate requestDelegate;

        public CheckForIPAddress(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            var ip = httpContext.Connection.RemoteIpAddress.ToString();
            httpContext.Items["ip"] = ip;

            await requestDelegate.Invoke(httpContext);
        }
    }
}
