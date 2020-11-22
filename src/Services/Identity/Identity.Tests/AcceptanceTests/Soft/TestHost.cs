using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Sooduskorv.IDP.Tests.AcceptanceTests.Soft
{
    public class TestHost<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        /*protected override void ConfigureWebHost(IWebHostBuilder builder)// TODO maybe need to use different configuration
        {
            // TODO
            base.ConfigureWebHost(builder);
        }*/

        private static void ensureDbsAreCreated(IServiceProvider s, Type[] types)
        {
            foreach (var t in types) ensureDbIsCreated(s, t);
        }

        private static void ensureDbIsCreated(IServiceProvider s, Type t)
        {
            if (!(s.GetRequiredService(t) is DbContext db))
                throw new ApplicationException($"DBContext {t} not found");
            db.Database.EnsureCreated();

            if (!db.Database.IsInMemory())
                throw new ApplicationException($"DBContext {t} is not in memory");
        }

        private static void addInMemoryDb<T>(IServiceCollection s) where T : DbContext
        {
            s.AddDbContext<T>(o => { o.UseInMemoryDatabase("WebMVCTests"); });
        }
        private static void removeCurrentDb<T>(IServiceCollection s) where T : DbContext
        {
            var descriptor = s.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<T>));

            if (descriptor != null) { s.Remove(descriptor); }
        }

        public T GetContext<T>() where T : DbContext
        {
            var scope = Services.CreateScope();
            var s = scope.ServiceProvider;

            return s.GetRequiredService<T>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}