using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;

namespace Asp.Omeno.Service.Persistence
{
    public class IdentityServerDbContext : ConfigurationDbContext
    {
        public IdentityServerDbContext(DbContextOptions<ConfigurationDbContext> options, ConfigurationStoreOptions storeOptions) : base(options, storeOptions) { }
    }
}
