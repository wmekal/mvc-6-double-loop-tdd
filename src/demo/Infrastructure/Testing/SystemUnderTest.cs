using System;
using Licensing.Web.Database;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Hosting.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;

namespace Licensing.Web.Infrastructure.Testing
{
    public class SystemUnderTest : IDisposable
    {
        private IHostingEngine _host;
        private IApplication _app;

        public SystemUnderTest()
        {
            Start();
        }

        private void Start()
        {
            var currentServiceProvider = CallContextServiceLocator.Locator.ServiceProvider;

            _host = new WebHostBuilder(new ConfigurationBuilder().Build(), true)
                .UseStartup<Startup>()
                .UseServer("Microsoft.AspNet.Server.Kestrel")
                .UseEnvironment("AcceptanceTesting")
                .UseServices(services => {
                    services.AddScoped(serviceProvider => new LicensingContextBuilder().InMemory().Build());
                })
                .Build();
            _app = _host.Start();
        }

        public void SetupData(Action<LicensingContext> setupData)
        {
            var context = _app.Services.GetService<LicensingContext>();

            setupData(context);
            context.SaveChanges();
        }

        public void Dispose()
        {
            if( _app != null )
            {
                _app.Dispose();
            }
        }
    }
}
