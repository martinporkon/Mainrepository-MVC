namespace Quantity.Pages {

    /*
    public sealed class MeasureTermsPage
        : ViewPage<IMeasureTermsRepository, MeasureTerm, MeasureTermView, MeasureTermData> {

        public MeasureTermsPage(IMeasureTermsRepository r, IMeasuresRepository m) :
            base(r, QuantityPagesNames.MeasureTerms) 
            => Measures = newItemsList<Measure, MeasureData>(m);


        public override Uri pageUrl() => new Uri(QuantityPagesUrls.MeasureTerms, UriKind.Relative);

        public override MeasureTerm toObject(MeasureTermView view) => MeasureTermViewFactory.Create(view);

        public override MeasureTermView toView(MeasureTerm obj) => MeasureTermViewFactory.Create(obj);

        public IEnumerable<SelectListItem> Measures { get; }

        public string MeasureName(string id) => itemName(Measures, id);

        public override string pageSubtitle() => MeasureName(FixedValue);

    }
    */

}

