using Aids.Reflection;
using Catalog.Data.Catalog;
using Catalog.Data.CatalogedProducts;
using Catalog.Data.CatalogEntries;
using Catalog.Data.Product;
using Catalog.Domain.Catalog;
using Catalog.Domain.Product;
using Catalog.Facade.Catalog;
using Catalog.Pages.Common.Consts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Pages.Catalog
{
    public sealed class CatalogEntryPage : ViewPage<ICatalogEntriesRepository, CatalogEntry,
        CatalogEntryView, CatalogEntryData>
    {

        public CatalogEntryPage(ICatalogEntriesRepository r, ICatalogsRepository pc, IProductCategoriesRepository ca)
            : base(r, ProductPagesNames.CatalogEntries)
        {
            Catalogs = newItemsList<Catalogs, CatalogData>(pc);
            Categories = newItemsList<ProductCategory, ProductCategoryData>(ca);
        }

        protected override Uri pageUrl() => new Uri(ProductPagesUrls.CatalogEntries, UriKind.Relative);

        protected override CatalogEntry toObject(CatalogEntryView view) =>
            CatalogEntryViewFactory.Create(view);

        protected override CatalogEntryView toView(CatalogEntry obj) => CatalogEntryViewFactory.Create(obj);
        public string CatalogName(string id) => itemName(Catalogs, id);

        public string CategoryName(string id) => itemName(Categories, id);

        public IEnumerable<SelectListItem> Catalogs { get; }

        public IEnumerable<SelectListItem> Categories { get; }

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
            Item = new CatalogEntryView()
            {
                Id = Guid.NewGuid().ToString(),
            };
        }

        protected override string pageSubtitle() => $"{CatalogName(FixedValue)}";

        public override async Task<IActionResult> OnGetDetailsAsync(string id, string sortOrder, string searchString,
    int pageIndex, string fixedFilter, string fixedValue)
        {
            var name = GetMember.Name<CatalogedProductData>(x => x.CatalogEntryId);
            var page = ProductPagesUrls.CatalogedProducts;
            var url = new Uri($"{page}/Index?handler=Index&fixedFilter={name}&fixedValue={id}", UriKind.Relative);

            await Task.CompletedTask.ConfigureAwait(false);

            return Redirect(url.ToString());
        }

    }

}
