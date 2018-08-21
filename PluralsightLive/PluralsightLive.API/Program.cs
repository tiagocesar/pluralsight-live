using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;

namespace PluralsightLive.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseSerilog(ConfigureSerilog)
                .UseStartup<Startup>();

        private static void ConfigureSerilog(WebHostBuilderContext ctx, LoggerConfiguration loggerConfiguration)
        {
            loggerConfiguration
                .WriteTo.Console();
        }
    }
}