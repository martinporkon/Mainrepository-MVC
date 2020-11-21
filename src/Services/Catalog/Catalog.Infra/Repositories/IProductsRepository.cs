using Catalog.Data.Product;
using Catalog.Data.UserProfiles;
using System;
using System.Collections.Generic;

namespace Catalog.Domain.Repositories
{
    public interface IProductsRepository
    {
        IEnumerable<ProductInstanceData> GetProducts();
        ProductInstanceData GetProduct(Guid id);
        bool Save();
        UserProfileData GetApplicationUserProfile(string subject);
        void AddApplicationUserProfile(UserProfileData applicationUserProfile);
        bool ApplicationUserProfileExists(string subject);
    }
}