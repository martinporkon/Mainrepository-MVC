using System.Net.Http;
using CommonTests.OverallTests;
using SooduskorvWebMVC;
using WebMVC.Tests.AcceptanceTests;

namespace WebMVC.Tests
{
    public abstract class BaseSoftTests : BaseTests
    {
        protected static readonly TestHost<Startup> host;
        protected static readonly HttpClient client;
        static BaseSoftTests()
        {
            host = new TestHost<Startup>();
            client = host.CreateClient();// TODO !!
        }
    }
}