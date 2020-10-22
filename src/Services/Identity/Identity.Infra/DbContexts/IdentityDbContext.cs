using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Identity.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infra.DbContexts
{
    public class IdentityDbContext : DbContext
    {
        public DbSet<UserData> Users { get; set; }

        public DbSet<UserClaim> UserClaims { get; set; }

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options) { }

        public static void InitializeTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserData>().ToTable(nameof(Users))
                .HasIndex(u => u.Subject)
                .IsUnique();

            modelBuilder.Entity<UserData>()
            .HasIndex(u => u.Username)
            .IsUnique();

            modelBuilder.Entity<UserData>().HasData(
                new UserData()
                {
                    Id = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                    Password = "password",
                    Subject = "d860efca-22d9-47fd-8249-791ba61b07c7",
                    Username = "Hanna",
                    Active = true
                },
                new UserData()
                {
                    Id = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                    Password = "password",
                    Subject = "b7539694-97e7-4dfe-84da-b4256e1ff5c7",
                    Username = "Bob",
                    Active = true
                });

            modelBuilder.Entity<UserClaim>().HasData(
             new UserClaim()
             {
                 Id = Guid.NewGuid(),
                 UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                 Type = "given_name",
                 Value = "Hanna"
             },
             new UserClaim()
             {
                 Id = Guid.NewGuid(),
                 UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                 Type = "family_name",
                 Value = "Forest"
             },
             new UserClaim()
             {
                 Id = Guid.NewGuid(),
                 UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                 Type = "email",
                 Value = "hanna@gmail.com"
             },
             new UserClaim()
             {
                 Id = Guid.NewGuid(),
                 UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                 Type = "address",
                 Value = "Tammsaare tee"
             },
             new UserClaim()
             {
                 Id = Guid.NewGuid(),
                 UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                 Type = "country",
                 Value = "somevalue"
             },
             new UserClaim()
             {
                 Id = Guid.NewGuid(),
                 UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                 Type = "given_name",
                 Value = "Bob"
             },
             new UserClaim()
             {
                 Id = Guid.NewGuid(),
                 UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                 Type = "family_name",
                 Value = "Oak"
             },
             new UserClaim()
             {
                 Id = Guid.NewGuid(),
                 UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                 Type = "email",
                 Value = "bob@gmail.com"
             },
             new UserClaim()
             {
                 Id = Guid.NewGuid(),
                 UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                 Type = "address",
                 Value = "Ehitajate Tee"
             },
             new UserClaim()
             {
                 Id = Guid.NewGuid(),
                 UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                 Type = "country",
                 Value = "somevalue"
             });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var updatedConcurrencyAwareEntries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified)
                .OfType<IConcurrency>();

            foreach (var entry in updatedConcurrencyAwareEntries)
            {
                entry.ConcurrencyStamp = Guid.NewGuid().ToString();
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            InitializeTables(modelBuilder);
        }
    }
}