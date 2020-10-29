using System;
using System.Collections.Generic;
using System.Text;
using Catalog.Infra.Services;
using Microsoft.Extensions.Logging;

namespace Catalog.Infra.Catalog
{
    public class CatalogRepository/* : Catalogs.CatalogsBase*/
    {
        private readonly ILogger _logger;

        public CatalogRepository(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("Database");
        }

        // TODO

    }
}