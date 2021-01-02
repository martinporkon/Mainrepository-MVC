using System.Net.Http;
using Sooduskorv.IDP;
using Sooduskorv.IDP.Tests.AcceptanceTests.Soft;
using Sooduskorv_MVC.CommonTests.OverallTests;

namespace WebMVC.Tests
{
    public abstract class BaseSoftTests : BaseTests
    {
        protected static readonly TestHost<Startup> host;
        protected static readonly HttpClient client;
        static BaseSoftTests()
        {
            host = new TestHost<Startup>();
            client = host.CreateClient();
        }
    }
}