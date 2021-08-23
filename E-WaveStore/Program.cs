using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Serilog;
/*using Serilog;*/

namespace E_WaveStore
{
    public class Program
    {
        public static void Main(string[] args)
        {

           /* var host = CreateHostBuilder(args).Build()*//*.Run()*/;
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            //
            //var logger = host.Services.GetRequiredService<ILogger<Program>>();
            //logger.LogInformation("The application started in {Time}", DateTime.UtcNow);

            //host.Run();

            try
            {
                Log.Information("Application starting up in {Time}", DateTime.UtcNow);
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "The application failed to start correctly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
            //
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                //Logging changes started

                .UseSerilog()

            #region
                //.ConfigureLogging((context, logging) =>
                //{
                //    logging.ClearProviders();
                //    logging.AddConfiguration(context.Configuration.GetSection("Logging"));
                //    logging.AddDebug();
                //    logging.AddConsole();
                //})
                //
            #endregion

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
