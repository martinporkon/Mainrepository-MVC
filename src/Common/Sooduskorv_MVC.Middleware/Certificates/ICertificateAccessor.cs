using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;

namespace Microsoft.AspNetCore.DataProtection
{
    public interface ICertificateAccessor
    {
        public X509Certificate2 LoadCertificate(IConfiguration configuration);
    }
}