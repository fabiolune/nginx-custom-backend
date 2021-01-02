using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Fabiolune.CustomBackend
{
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        public static void Main() =>
            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<Startup>()
                        .UseKestrel(_ => _.AddServerHeader = false);
                }).Build().Run();
    }
}
