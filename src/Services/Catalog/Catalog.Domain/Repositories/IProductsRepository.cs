using System;
using System.Collections.Generic;
using Catalog.Data.Products;
using Catalog.Data.UserProfiles;

namespace Catalog.Domain.Repositories
{
    public interface IProductsRepository
    {
        IEnumerable<ProductData> GetProducts();
        ProductData GetProduct(Guid id);
        bool Save();
        UserProfile GetApplicationUserProfile(string subject);
        void AddApplicationUserProfile(UserProfile applicationUserProfile);
        bool ApplicationUserProfileExists(string subject);
    }
}