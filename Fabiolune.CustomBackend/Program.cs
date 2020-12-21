using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Fabiolune.CustomBackend
{
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
