using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace dnd_graphql_svc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
               .Enrich.FromLogContext()
               .MinimumLevel.Debug()
               .WriteTo.Console()
               .WriteTo.File("log.txt", rollingInterval:RollingInterval.Day)
               .CreateLogger();
            //.WriteTo.Console( Serilog.Events.LogEventLevel.Verbose,"{NewLine}{Timestamp:HH:mm:ss} [{Level}] ({CorrelationToken}) {Message}{NewLine}{Exception}")

            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            finally 
            {
                Log.CloseAndFlush();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.ClearProviders();

                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    //build in providers
                    logging.AddConsole();
                    logging.AddDebug();
                    //logging.AddEventSourceLogger();
                    //logging.AddTraceSource(sourceSwitchName);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }


}
