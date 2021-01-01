using System;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Facade;
using Quantity.Pages.Common;
using Quantity.Pages.Common.Consts;

namespace Quantity.Pages {

    public sealed class SystemsOfUnitsPage
        : ViewPage<ISystemsOfUnitsRepository, SystemOfUnits, SystemOfUnitsView, SystemOfUnitsData> {

        public SystemsOfUnitsPage(ISystemsOfUnitsRepository r) 
            : base(r, QuantityPagesNames.SystemsOfUnits) { }

        public override Uri pageUrl() => new Uri(QuantityPagesUrls.SystemsOfUnits, UriKind.Relative);

        public override SystemOfUnits toObject(SystemOfUnitsView view) =>
            SystemOfUnitsViewFactory.Create(view);

        public override SystemOfUnitsView toView(SystemOfUnits obj) => SystemOfUnitsViewFactory.Create(obj);

    }
}

