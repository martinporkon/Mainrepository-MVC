namespace Quantity.Core.Rounding
{
    public interface IRoundingPolicy {

        double Round(double amount);
        decimal Round(decimal amount);

    }
}
