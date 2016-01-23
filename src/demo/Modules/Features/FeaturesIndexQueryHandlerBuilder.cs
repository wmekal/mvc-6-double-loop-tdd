using System;
using Licensing.Web.Database;
using Licensing.Web.Infrastructure.Testing;

namespace Licensing.Web.Modules.Features
{
    internal class FeaturesIndexQueryHandlerBuilder
    {
        private readonly LicensingContext _context;

        public FeaturesIndexQueryHandlerBuilder()
        {
            _context = new LicensingContextBuilder().InMemory().Build();

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        public FeaturesIndexQueryHandlerBuilder WithData(Action<LicensingContext> setupAction)
        {
            setupAction(_context);
            _context.SaveChanges();

            return this;
        }

        public FeaturesIndexQueryHandler Build()
        {
            return new FeaturesIndexQueryHandler(_context);
        }
    }
}
