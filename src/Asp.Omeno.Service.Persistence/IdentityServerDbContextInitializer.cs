using Asp.Omeno.Service.Application.Configurations;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using System.Linq;

namespace Asp.Omeno.Service.Persistence
{
    public class IdentityServerDbContextInitializer
    {
        public static void Initialize(ConfigurationDbContext context)
        {
            new IdentityServerDbContextInitializer().Seed(context);
        }
        private void Seed(ConfigurationDbContext context)
        {
            context.Database.EnsureCreated();

            SeedClients(context);
            SeedApiResources(context);
            SeedIdentityResources(context);
        }
        private void SeedClients(ConfigurationDbContext context)
        {
            if (context.Clients.Any()) return;

            context.Clients.AddRange(IdentityConfig.GetClients().Select(x => x.ToEntity()).ToList());

            context.SaveChanges();
        }
        private void SeedApiResources(ConfigurationDbContext context)
        {
            if (context.ApiResources.Any()) return;

            context.ApiResources.AddRange(IdentityConfig.GetApiResources().Select(x => x.ToEntity()).ToList());

            context.SaveChanges();
        }

        private void SeedIdentityResources(ConfigurationDbContext context)
        {
            if (context.IdentityResources.Any()) return;

            context.IdentityResources.AddRange(IdentityConfig.GetIdentityResources().Select(x => x.ToEntity()).ToList());

            context.SaveChanges();
        }
    }
}
