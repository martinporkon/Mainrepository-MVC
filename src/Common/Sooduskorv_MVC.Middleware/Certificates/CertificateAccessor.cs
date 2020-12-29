using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;

namespace Microsoft.AspNetCore.DataProtection
{
    public class CertificateAccessor : ICertificateAccessor
    {
        public X509Certificate2 LoadCertificate(IConfiguration c)
        {
            using var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            var certificates = store.Certificates.Find(X509FindType.FindByThumbprint,
                c.GetSection("tb"), true);
            if (certificates.Count is 0) throw new Exception("Certificate was not found.");
            return certificates[0];
        }
    }
}