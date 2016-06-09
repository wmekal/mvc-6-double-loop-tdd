using System;
using System.IO;
using Licensing.Web.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Licensing.Web.Infrastructure.Testing
{
    public class SystemUnderTest : IDisposable
    {
        private IWebHost _host;

        public SystemUnderTest()
        {
            Start();
        }

        private void Start()
        {
            _host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\"))
                .UseStartup<Startup>()
                .UseEnvironment("AcceptanceTesting")
                .ConfigureServices(services => {
                    services.AddScoped(serviceProvider => new LicensingContextBuilder().InMemory().Build());
                })
                .Build();

            _host.Start();
        }

        public void SetupData(Action<LicensingContext> setupData)
        {
            var context = _host.Services.GetService<LicensingContext>();

            setupData(context);
            context.SaveChanges();
        }

        public void Dispose()
        {
            if( _host != null )
            {
                _host.Dispose();
            }
        }
    }
}
