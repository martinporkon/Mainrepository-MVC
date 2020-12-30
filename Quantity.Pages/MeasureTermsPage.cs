using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Facade;
using Quantity.Pages.Common;
using Quantity.Pages.Common.Consts;

namespace Quantity.Pages {

    public sealed class MeasureTermsPage
        : ViewPage<IMeasureTermsRepository, MeasureTerm, MeasureTermView, MeasureTermData> {

        public MeasureTermsPage(IMeasureTermsRepository r, IMeasuresRepository m) :
            base(r, QuantityPagesNames.MeasureTerms) 
            => Measures = newItemsList<Measure, MeasureData>(m);


        protected internal override Uri pageUrl() => new Uri(QuantityPagesUrls.MeasureTerms, UriKind.Relative);

        protected internal override MeasureTerm toObject(MeasureTermView view) => MeasureTermViewFactory.Create(view);

        protected internal override MeasureTermView toView(MeasureTerm obj) => MeasureTermViewFactory.Create(obj);

        public IEnumerable<SelectListItem> Measures { get; }

        public string MeasureName(string id) => itemName(Measures, id);

        protected internal override string pageSubtitle() => MeasureName(FixedValue);

    }

}

