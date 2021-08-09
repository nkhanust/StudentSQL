using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using StudentSQL.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSQL
{
    public class Program
    {

        public static void Main(string[] args)
        {

            var builder = new ConfigurationBuilder();
            BuildConfig(builder);
            //This is the setup for the logger
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }




        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });




        static void BuildConfig(IConfigurationBuilder builder)
        {
            //This tells our builder the ability to talk to appsettings.json in the current directory
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                //This obtains the whatever enviroment it is running and override it, if it doesnt find any enviroment, run production.json
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIROMENT") ?? "Prodution"}.json", optional: true)
                .AddEnvironmentVariables();
            //write it t a text file instead of console.
        }
    }

}

