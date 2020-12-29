using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Serilog;

namespace Microsoft.AspNetCore.Builder
{
    public static class DbContextExtensions
    {
        public static bool Exists(this DatabaseFacade source) => source.GetService<IRelationalDatabaseCreator>().Exists();

        public static async Task<(HealthStatus, bool)> CanConnectToDatabaseAsync(this DbContext dbContext, string service)
        {
            try { if (await dbContext.Database.CanConnectAsync()) return (HealthStatus.Healthy, true); }
            catch (Exception e)
            {
                Log.Warning("Cannot connect to the database", e);
                Log.Fatal($"{service} FATAL ERROR. Database is not configured or connected to the service", e);
            }
            return (HealthStatus.Degraded, false);
        }
    }
}