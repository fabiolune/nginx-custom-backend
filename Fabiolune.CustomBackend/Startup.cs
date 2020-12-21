using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Fabiolune.CustomBackend
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.MapWhen(_ => _.Request.Path.Equals("/healthz"), _ =>
            {
                _.Run(__ =>
                {
                    __.Response.StatusCode = (int) HttpStatusCode.OK;
                    return __.Response.WriteAsJsonAsync(new { status = "healthy"});
                });
            });
            app.Run(_ =>
            {
                _.Response.StatusCode = (int) HttpStatusCode.NotFound;
                return _.Response.WriteAsJsonAsync(new { status = "not-found" });
            });
        }
    }
}
