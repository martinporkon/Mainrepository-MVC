using System.Collections.Generic;
using WebMVC.Bff.HttpAggregator.Domain.Common;
using WebMVC.Bff.HttpAggregator.Domain.CurrentService.Entities;

namespace WebMVC.Bff.HttpAggregator.Domain.CurrentService.CurrentServiceQuery
{
    public class PictureQuery : IQuery<Resource>
    {
        // get from the database and join with the requested products for joined json.
        public IEnumerable<string> Ids { get; set; }
    }
}