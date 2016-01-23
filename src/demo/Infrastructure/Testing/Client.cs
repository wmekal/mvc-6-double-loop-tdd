using System;
using Coypu;

namespace Licensing.Web.Infrastructure.Testing
{
    public class Client : IDisposable
    {
        public Client()
        {
            Start();
        }

        private void Start()
        {
            Browser = new BrowserSession(new SessionConfiguration
            {
                AppHost = "localhost",
                Port = 5000,
                SSL = false,
                Driver = typeof(Coypu.Drivers.Selenium.SeleniumWebDriver),
                Browser = Coypu.Drivers.Browser.PhantomJS
            });
        }

        public BrowserSession Browser { get; set; }

        public void Dispose()
        {
            if( Browser != null )
            {
                Browser.Dispose();
            }
        }
    }
}
