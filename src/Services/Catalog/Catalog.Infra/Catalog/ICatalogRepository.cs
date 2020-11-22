using System;
using System.Collections.Generic;
using Catalog.Data.Products;
using Catalog.Data.UserProfiles;

namespace Catalog.Infra.Catalog
{
    public interface ICatalogRepository
    {
        IEnumerable<ProductData> GetProducts();
        ProductData GetProduct(Guid id);
        bool Save();
        UserProfileData GetApplicationUserProfile(string subject);
        void AddApplicationUserProfile(UserProfileData applicationUserProfile);
        bool ApplicationUserProfileExists(string subject);
    }
}