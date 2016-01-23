using TestStack.BDDfy;
using Xunit;

namespace Licensing.Web.Modules.Features
{
    [Trait("category", "acceptance")]
    [Collection("acceptance")]
    public class FeaturesIndexTests : IClassFixture<FeaturesIndexTestsContext>
    {
        private readonly FeaturesIndexTestsContext _context;

        public FeaturesIndexTests(FeaturesIndexTestsContext context)
        {
            _context = context;
        }

        [Fact]
        public void No_Features_Defined_In_The_System()
        {
            _context
                .Given(c => c.ThereAreNoFeatures())           // Given there are no features
                .When(c => c.IGoToFeaturesPage())             // When I go to features page
                .Then(c => c.ISeeATextNoFeaturesDefinedYet()) // Then I see a text
                .BDDfy("No_Features_Defined_In_The_System");  //     'There are no features defined yet.'.
        }

        [Fact]
        public void Features_Defined_In_The_System()
        {
            _context
                .Given(c => c.ThereAreDefinedFeatures()) // Given there are defined features
                .When(c => c.IGoToFeaturesPage())        // When I go to features page
                .Then(c => c.ISeeAllDefinedFeatures())   // Then I see all defined features
                .BDDfy("Features_Defined_In_The_System");
        }
    }
}
