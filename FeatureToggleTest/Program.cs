using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace FeatureToggleTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .ConfigureAppConfiguration((hostingContext, config) =>
                        {
                            var settings = config.Build();

                            config.AddAzureAppConfiguration(opts =>
                            {
                                opts.Connect(settings["ConnectionStrings:AppConfig"])
                                    .UseFeatureFlags(opts => { opts.CacheExpirationTime = TimeSpan.FromSeconds(5); });
                            });
                        })
                        .UseStartup<Startup>();
                });
    }
}