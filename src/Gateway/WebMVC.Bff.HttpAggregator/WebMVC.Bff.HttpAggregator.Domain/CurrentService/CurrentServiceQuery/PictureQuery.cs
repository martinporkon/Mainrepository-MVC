using System;
using System.Collections.Generic;
using System.Text;
using WebMVC.Bff.HttpAggregator.Domain.CurrentService.Entities;
using WebMVC.Bff.HttpAggregator.Infra.Common;

namespace WebMVC.Bff.HttpAggregator.Domain.CurrentService.CurrentServiceQuery
{
    public class PictureQuery : IQuery<Resource>
    {
        // get from the database and join with the requested products for joined json.
        public IEnumerable<string> Ids { get; set; }
    }
}