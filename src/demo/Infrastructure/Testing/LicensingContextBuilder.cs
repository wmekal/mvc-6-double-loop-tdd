using Licensing.Web.Database;
using Microsoft.Data.Entity;

namespace Licensing.Web.Infrastructure.Testing
{
    public class LicensingContextBuilder
    {
        private readonly DbContextOptionsBuilder _optionsBuilder;

        public LicensingContextBuilder()
        {
            _optionsBuilder = new DbContextOptionsBuilder();
        }

        public LicensingContextBuilder InMemory()
        {
            _optionsBuilder.UseInMemoryDatabase();
            return this;
        }

        public LicensingContext Build()
        {
            return new LicensingContext(_optionsBuilder.Options);
        }
    }
}
