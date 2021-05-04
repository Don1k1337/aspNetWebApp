using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Danil_Popov_1040.Middleware;

namespace Danil_Popov_1040.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder UseFileLogging(this
        IApplicationBuilder app)
        => app.UseMiddleware<LogMiddleware>();
    }
}
