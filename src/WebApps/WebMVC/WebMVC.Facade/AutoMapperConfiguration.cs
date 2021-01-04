using System;
using Web.Facade.Basket.Baskets;

namespace Web.Facade.Profiles
{
    public static class AutoMapperConfiguration
    {
        public static Type[] RegisterMappings()
        {
            return new Type[]
            {
                typeof(BasketViewFactoryProfile)
            };
        }
    }
}