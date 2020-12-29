using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Sooduskorv.IDP.Middleware.DbContextStore
{
    public static class DbContextStoreMiddlewareExtensions
    {
        private static string _connection = "Default";
        private static void SetDatabase(this DbContextOptionsBuilder b, string connectionString, string name)
        {
            b.UseSqlServer(connectionString,
                o => o.MigrationsAssembly(name));
        }

        public static IIdentityServerBuilder AddCustomConfigurationStore(this IIdentityServerBuilder b, string name)
        {
            b.AddConfigurationStore(o =>
            {
                o.ConfigureDbContext = builder => builder.SetDatabase(_connection, name);
            });
            return b;
        }

        public static IIdentityServerBuilder AddCustomOperationalStore(this IIdentityServerBuilder b, string name)
        {
            b.AddOperationalStore(o =>
            {
                o.ConfigureDbContext = builder => builder.SetDatabase(_connection, name);
            });
            return b;
        }
    }
}