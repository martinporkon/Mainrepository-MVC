using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Facade;
using Quantity.Facade.Common;
using Quantity.Pages.Common;
using Quantity.Pages.Common.Consts;
using Sooduskorv_MVC.Aids.Reflection;

namespace Quantity.Pages {

    public sealed class UnitsPage : ViewPage<IUnitsRepository, Unit, UnitView, UnitData> {

        internal readonly IUnitTermsRepository terms;
        internal readonly IUnitFactorsRepository factors;

        public UnitsPage(IUnitsRepository r, IMeasuresRepository m
            , IUnitTermsRepository t, IUnitFactorsRepository f) : base(r, QuantityPagesNames.Units) {
            Measures = newItemsList<Measure, MeasureData>(m);
            Terms = new List<UnitTermView>();
            Factors = new List<UnitFactorView>();
            terms = t;
            factors = f;
        }

        public IEnumerable<SelectListItem> Measures { get; }
        public IList<UnitTermView> Terms { get; }
        public IList<UnitFactorView> Factors { get; }

        public override Uri pageUrl() => new Uri(QuantityPagesUrls.Units, UriKind.Relative);

        public override string pageSubtitle()  => MeasureName(FixedValue);

        public override Unit toObject(UnitView view) => UnitViewFactory.Create(view);

        public override UnitView toView(Unit obj) => UnitViewFactory.Create(obj);

        public string MeasureName(string id) => itemName(Measures, id);

        public void LoadDetails(UnitView item) {
            loadTerms(item);
            loadFactors(item);
        }

        private void loadFactors(UniqueEntityView item) => loadDetails(Factors, factors, 
            item, GetMember.Name<UnitFactorData>(x => x.UnitId), UnitFactorViewFactory.Create);

        private void loadTerms(UniqueEntityView item) => loadDetails(Terms, terms, item,
            GetMember.Name<UnitTermData>(x => x.MasterId), UnitTermViewFactory.Create);
    }

}
