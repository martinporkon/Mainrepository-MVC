using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Bff.HttpAggregator.Core.Errors
{
    public readonly struct ErrorMappingVisitor<TModel> : IErrorVisitor<ActionResult<TModel>>
    {
        public ActionResult<TModel> Visit(NotFound result)
            => new NotFoundObjectResult(result.Message);

        public ActionResult<TModel> Visit(Invalid result)
            => new BadRequestObjectResult(result.Message);

        public ActionResult<TModel> Visit(Unauthorized result)
            => new StatusCodeResult(StatusCodes.Status403Forbidden);

    }
}