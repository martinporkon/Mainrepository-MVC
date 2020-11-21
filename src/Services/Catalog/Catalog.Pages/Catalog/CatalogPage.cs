using Aids.Reflection;
using Catalog.Data.Catalog;
using Catalog.Data.CatalogEntries;
using Catalog.Domain.Catalog;
using Catalog.Facade.Catalog;
using Catalog.Pages.Common.Consts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Pages.Catalog
{
    public  class CatalogPage : ViewPage<ICatalogsRepository, Catalogs,
         CatalogView, CatalogData>
    {

        public CatalogPage(ICatalogsRepository r)
            : base(r, ProductPagesNames.Catalogs) { }

        protected internal override Uri pageUrl() => new Uri("Catalog", UriKind.Relative);

        protected internal override Catalogs toObject(CatalogView view) =>
            CatalogViewFactory.Create(view);

        protected internal override CatalogView toView(Catalogs obj) => CatalogViewFactory.Create(obj);

        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            createItem();

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }

        private void createItem()
        {
            Item = new CatalogView()
            {
                Id = Guid.NewGuid().ToString(),
            };
        }

        public override async Task<IActionResult> OnGetDetailsAsync(string id, string sortOrder, string searchString,
            int pageIndex, string fixedFilter, string fixedValue)
        {
            var name = GetMember.Name<CatalogEntryData>(x => x.CatalogId);
            var page = ProductPagesUrls.CatalogEntries;
            var url = new Uri($"{page}/Index?handler=Index&fixedFilter={name}&fixedValue={id}", UriKind.Relative);

            await Task.CompletedTask.ConfigureAwait(false);

            return Redirect(url.ToString());
        }

    }
}
