using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Facade;
using Quantity.Pages.Common;
using Quantity.Pages.Common.Consts;

namespace Quantity.Pages {

    public sealed class UnitFactorsPage 
        : ViewPage<IUnitFactorsRepository, UnitFactor, UnitFactorView, UnitFactorData> {

        public UnitFactorsPage(IUnitFactorsRepository r, IUnitsRepository u, ISystemsOfUnitsRepository s) :
            base(r, QuantityPagesNames.UnitFactors) {
            Units = newItemsList<Unit, UnitData>(u);
            Systems = newItemsList<SystemOfUnits, SystemOfUnitsData>(s);
        }

        public override Uri pageUrl() => new Uri(QuantityPagesUrls.UnitFactors, UriKind.Relative);

        public override UnitFactor toObject(UnitFactorView view) => UnitFactorViewFactory.Create(view);

        public override UnitFactorView toView(UnitFactor obj) => UnitFactorViewFactory.Create(obj);

        public IEnumerable<SelectListItem> Units { get; }
        public IEnumerable<SelectListItem> Systems { get; }

        public string UnitName(string id) => itemName(Units, id);

        public string SystemName(string id) => itemName(Systems, id);

        public override string pageSubtitle() => UnitName(FixedValue);

    }

}


