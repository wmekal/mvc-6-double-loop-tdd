using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Licensing.Web.Models;

namespace Licensing.Web.Database
{
    public class LicensingContext : DbContext
    {
        public LicensingContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Feature> Features { get; set; }
    }
}
