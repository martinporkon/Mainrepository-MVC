using System;
using Microsoft.AspNetCore.Mvc.Testing;

namespace WebMVC.Tests.AcceptanceTests
{
    public class TestHost<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        /*protected override void ConfigureWebHost(IWebHostBuilder builder)// TODO maybe need to use different configuration
        {
            // TODO
            base.ConfigureWebHost(builder);
        }*/

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public void Dispose()// TODO
        {
            Dispose(true);
            try
            {
                GC.SuppressFinalize(this);
            }
            catch (Exception e)
            {
                Log.Exception(e);
                throw;
            }

        }
    }
}