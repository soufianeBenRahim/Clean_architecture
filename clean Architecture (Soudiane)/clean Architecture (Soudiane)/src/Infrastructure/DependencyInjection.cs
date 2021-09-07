using Clean_Architecture_Soufiane.Application.Common.Interfaces;
using Clean_Architecture_Soufiane.BuildingBlocks.IntegrationEventLogEF;
using Clean_Architecture_Soufiane.Domain.Seedwork;
using Clean_Architecture_Soufiane.Infrastructure.Persistence;
using Clean_Architecture_Soufiane.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clean_Architecture_Soufiane.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseInMemoryDatabase("Clean_Architecture_SoufianeDb"));
                services.AddDbContext<IntegrationEventLogContext>(options =>
                  options.UseInMemoryDatabase("Clean_Architecture_SoufianeDb"));
                
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
                services.AddDbContext<IntegrationEventLogContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(IntegrationEventLogContext).Assembly.FullName)));

            }


            services.AddScoped<IDomainEventService, DomainEventService>();

            services.AddTransient<IDateTime, DateTimeService>();

            return services;
        }
    }
}