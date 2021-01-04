using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;

namespace Sooduskorv_MVC.Middleware
{
    public interface ICertificateAccessor
    {
        public X509Certificate2 LoadCertificate(IConfiguration configuration);
    }
}