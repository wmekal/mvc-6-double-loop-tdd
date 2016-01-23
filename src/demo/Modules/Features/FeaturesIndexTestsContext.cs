using Xunit;
using Licensing.Web.Infrastructure.Testing;
using Licensing.Web.Models;

namespace Licensing.Web.Modules.Features
{
    [Collection("acceptance")]
    public class FeaturesIndexTestsContext
    {
        private readonly SystemUnderTest _system;
        private readonly Client _client;

        public FeaturesIndexTestsContext(SystemUnderTest system, Client client)
        {
            _system = system;
            _client = client;
        }

        private void ResetDb()
        {
            _system.SetupData(context => {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            });
        }

        public void ThereAreNoFeatures()
        {
            ResetDb();
        }

        public void IGoToFeaturesPage()
        {
            _client.Browser.Visit("/features");
        }

        public void ISeeATextNoFeaturesDefinedYet()
        {
            Assert.True(
                _client.Browser.HasContent("There are no features defined yet.")
            );
        }

        public void ThereAreDefinedFeatures()
        {
            ResetDb();

            _system.SetupData(context => {
                context.Add(new Feature { Name = "feature 1" });
                context.Add(new Feature { Name = "feature 2" });
            });
        }

        public void ISeeAllDefinedFeatures()
        {
            var table = _client.Browser
                .FindCss("table");

            Assert.True(
                table.Exists()
                    && table.HasContent("feature 1")
                    && table.HasContent("feature 2")
            );
        }
    }
}
