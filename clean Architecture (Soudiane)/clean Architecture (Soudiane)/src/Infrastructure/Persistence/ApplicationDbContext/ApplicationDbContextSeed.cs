namespace Clean_Architecture_Soufiane.Infrastructure.Persistence
{

    using Microsoft.AspNetCore.Hosting;

    using Microsoft.Extensions.Logging;

    using System.Threading.Tasks;

    public class ApplicationDbContextSeed
    {
        public async Task SeedAsync(ApplicationDbContext context, IWebHostEnvironment env, bool useCustomizationData , ILogger<ApplicationDbContextSeed> logger)
        {

            using (context)
            {
                  

            }
        }
    }
}
