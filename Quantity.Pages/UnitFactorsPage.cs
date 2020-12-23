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

        protected internal override Uri pageUrl() => new Uri(QuantityPagesUrls.UnitFactors, UriKind.Relative);

        protected internal override UnitFactor toObject(UnitFactorView view) => UnitFactorViewFactory.Create(view);

        protected internal override UnitFactorView toView(UnitFactor obj) => UnitFactorViewFactory.Create(obj);

        public IEnumerable<SelectListItem> Units { get; }
        public IEnumerable<SelectListItem> Systems { get; }

        public string UnitName(string id) => itemName(Units, id);

        public string SystemName(string id) => itemName(Systems, id);

        protected internal override string pageSubtitle() => UnitName(FixedValue);

    }

}


