using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Domain.Catalog;
using Catalog.Facade.Catalog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SooduskorvWebMVC.Controllers
{
    public class CatalogController : Catalog.Pages.Catalog.CatalogPage
    {
        public CatalogController(ICatalogsRepository r)
            : base(r) { }

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

    }
}
