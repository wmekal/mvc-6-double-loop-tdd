using Licensing.Web.Models;
using Microsoft.EntityFrameworkCore;

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
