using System;
using System.Collections.Generic;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Facade;
using Quantity.Pages.Common;
using Quantity.Pages.Common.Consts;
using Sooduskorv_MVC.Aids.Reflection;

namespace Quantity.Pages
{
    /*public sealed class MeasuresPage
        : ViewPage<IMeasuresRepository, Measure, MeasureView, MeasureData>
    {

        internal readonly IMeasureTermsRepository terms;

        public MeasuresPage(IMeasuresRepository r, IMeasureTermsRepository t)
            : base(r, QuantityPagesNames.Measures)
        {
            Terms = new List<MeasureTermView>();
            terms = t;
        }

        public override Uri pageUrl() => new Uri(QuantityPagesUrls.Measures, UriKind.Relative);

        public override Measure toObject(MeasureView view) => MeasureViewFactory.Create(view);

        public override MeasureView toView(Measure obj) => MeasureViewFactory.Create(obj);

        public IList<MeasureTermView> Terms { get; }

        public void LoadDetails(MeasureView item) =>
            loadDetails(Terms, terms, item,
                GetMember.Name<MeasureTermData>(x => x.MasterId),
                MeasureTermViewFactory.Create);

    }*/

}