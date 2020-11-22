namespace WebMVC.Bff.HttpAggregator.Core.Errors
{
    public interface IErrorVisitor<out TVisitResult>
    {
        TVisitResult Visit(NotFound result);

        TVisitResult Visit(Invalid result);

        TVisitResult Visit(Unauthorized result);
    }
}