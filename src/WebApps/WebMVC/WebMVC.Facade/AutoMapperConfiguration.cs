using System;
using WebMVC.Facade.BasketView;

namespace WebMVC.Facade.Profiles
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