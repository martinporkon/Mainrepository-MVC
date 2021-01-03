using Microsoft.Extensions.DependencyInjection;
using Quantity.Domain;

namespace Quantity.Infra {

    public static class QuantityRepositories {

        public static void Register(IServiceCollection services) {
            services.AddScoped<IMeasuresRepository, MeasuresRepository>();
            services.AddScoped<IUnitsRepository, UnitsRepository>();
            services.AddScoped<ISystemsOfUnitsRepository, SystemsOfUnitsRepository>();
            services.AddScoped<IUnitTermsRepository, UnitTermsRepository>();
            services.AddScoped<IUnitFactorsRepository, UnitFactorsRepository>();
            services.AddScoped<IUnitRulesRepository, UnitRulesRepository>();
            services.AddScoped<IMeasureTermsRepository, MeasureTermsRepository>();
        }

    }

}
