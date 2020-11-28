using Aids.Methods;
using Catalog.Data.Product;
using Catalog.Domain.Product;
using Catalog.Facade.Product;
using Catalog.Pages.Common.Consts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Pages.Products
{
    public sealed class ProductInstancesPage : ViewsPage<IProductInstancesRepository, IProductInstance, ProductInstanceView, ProductInstanceData>
    {

        private readonly IProductTypesRepository productTypesRepository;

        public IEnumerable<SelectListItem> ProductTypes { get; private set; }
        //public IEnumerable<SelectListItem> Units { get; }
        public ProductKind ProductKind { get; internal set; }

        public ProductInstancesPage(IProductInstancesRepository r,
            //IUnitsRepository u,
            IProductTypesRepository t)
            : base(r, ProductPagesNames.ProductInstances)
        {
            productTypesRepository = t;
           
            //Units = newItemsList<Unit, UnitData>(u);
        }

        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            ProductKind = Safe.Run(() => (ProductKind)(switchOfCreate ?? 1000), ProductKind.Unspecified);

            createItem();

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }

        private void createItem()
        {
            Item = new ProductInstanceView()
            {
                ProductKind = ProductKind,
                Id = Guid.NewGuid().ToString(),
            };
            updateProductTypes();
        }

        internal void updateProductTypes()
            => ProductTypes =
                newItemsList<IProductType, ProductTypeData>(productTypesRepository, d => d.ProductKind == ProductKind);

        protected internal override Uri pageUrl() => new Uri(ProductPagesUrls.ProductInstances, UriKind.Relative);

        protected internal override IProductInstance toObject(ProductInstanceView view) => ProductInstanceViewFactory.Create(view);

        protected internal override ProductInstanceView toView(IProductInstance obj)
        {
            ProductKind = obj.ProductKind;
            updateProductTypes();
            return ProductInstanceViewFactory.Create(obj);
        }

        public string ProductTypeName(string id) => itemName(ProductTypes, id);

      //  public string UnitName(string id) => itemName(Units, id);

        public Uri CreateUri(ProductKind k) => createUri((int)k);



        private static string subTitle(string item, string name) => $"For {item} ({name})";

        private static string removeId(string idField) => idField?.Replace("Id", string.Empty) ?? string.Empty;
    }
}
