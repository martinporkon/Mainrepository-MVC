namespace WebMVC.Bff.HttpAggregator.Core.Errors
{
    public sealed class Invalid : Error
    {
        public Invalid(string message)
        {
            Message = message;
        }

        public string Message { get; }

        public override TResult Accept<TVisitor, TResult>(TVisitor visitor)
            => visitor.Visit(this);
    }
}