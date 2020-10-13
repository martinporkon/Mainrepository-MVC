using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Data.Products;
using Catalog.Data.UserProfiles;
using Catalog.Infra;

namespace Catalog.Domain.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private CatalogDbContext _context;

        public ProductsRepository(CatalogDbContext applicationDbContext)
        {
            _context = applicationDbContext ??
                       throw new ArgumentNullException(nameof(applicationDbContext));
        }

        public UserProfileData GetApplicationUserProfile(string subject)
        {
            return _context.UserProfiles.FirstOrDefault(a => a.Subject == subject);
        }

        public bool ApplicationUserProfileExists(string subject)
        {
            return _context.UserProfiles.Any(a => a.Subject == subject);
        }

        public void AddApplicationUserProfile(UserProfileData applicationUserProfile)
        {
            _context.UserProfiles.Add(applicationUserProfile);
        }

        public IEnumerable<ProductData> GetProducts()
        {
            throw new NotImplementedException("Not implemented");
        }

        public ProductData GetProduct(Guid id)
        {
            return _context.Products.FirstOrDefault(i => i.Id == id.ToString());
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}