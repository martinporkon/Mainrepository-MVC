using System;
using Web.Facade.Baskets.BasketView;

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