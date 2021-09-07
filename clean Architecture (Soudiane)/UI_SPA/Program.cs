using Clean_Architecture_Soufiane.BuildingBlocks.IntegrationEventLogEF;
using Clean_Architecture_Soufiane.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_SPA
{
    public class Program
    {
        public static string Namespace = typeof(Startup).Namespace;
        public static string AppName = Namespace.Substring(Namespace.LastIndexOf('.', Namespace.LastIndexOf('.') - 1) + 1);
        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            //  avec la migration
           
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var SaleContext = services.GetRequiredService<ApplicationDbContext>();

                    if (SaleContext.Database.IsSqlServer())
                    {
                        // recriation des table 
                        SaleContext.Database.EnsureDeleted();
                        SaleContext.Database.EnsureCreated();
                        // avec migration
                        //SaleContext.Database.Migrate();

                    }
                    var IntegrationEventContext = services.GetRequiredService<IntegrationEventLogContext>();
                    if (IntegrationEventContext.Database.IsSqlServer())
                    {
                        // recriation des table 
                        IntegrationEventContext.Database.EnsureDeleted();
                        IntegrationEventContext.Database.EnsureCreated();
                        // avec migration
                        //IntegrationEventContext.Database.Migrate();
                    }
                    var env = services.GetService<IWebHostEnvironment>();
                    var logger = services.GetService<ILogger<ApplicationDbContextSeed>>();

                    var loggerSales = services.GetService<ILogger<ApplicationDbContextSeed>>();
                    new ApplicationDbContextSeed().SeedAsync(SaleContext, env, true, logger)
                                                       .Wait();

                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

                    logger.LogError(ex, "An error occurred while migrating or seeding the database.");

                    throw;
                }
            }
           
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
