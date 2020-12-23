using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Facade;
using Quantity.Pages.Common;
using Quantity.Pages.Common.Consts;

namespace Quantity.Pages {

    public sealed class UnitTermsPage : ViewPage<IUnitTermsRepository, UnitTerm, UnitTermView, UnitTermData> {

        public UnitTermsPage(IUnitTermsRepository r, IUnitsRepository u)
            : base(r, QuantityPagesNames.UnitTerms)
            => Units = newItemsList<Unit, UnitData>(u);

        protected internal override Uri pageUrl() => new Uri(QuantityPagesUrls.UnitTerms, UriKind.Relative);

        protected internal override UnitTerm toObject(UnitTermView view) => UnitTermViewFactory.Create(view);

        protected internal override UnitTermView toView(UnitTerm obj) => UnitTermViewFactory.Create(obj);

        public IEnumerable<SelectListItem> Units { get; }

        public string UnitName(string id) => itemName(Units, id);

        protected internal override string pageSubtitle() => UnitName(FixedValue);

    }

}

