using Xunit;

namespace Licensing.Web.Infrastructure.Testing
{
    [CollectionDefinition("acceptance")]
    public class AcceptanceCollection : ICollectionFixture<SystemUnderTest>, ICollectionFixture<Client>
    {

    }
}
