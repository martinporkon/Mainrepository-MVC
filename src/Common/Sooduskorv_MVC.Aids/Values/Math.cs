using System;

namespace Sooduskorv_MVC.Aids.Values
{
    public static class Math
    {
        public delegate object MathOperation(object left, object right);

        private static MathOperation GetOperation(char operation)
        {
            return operation switch
            {
                '+' => Calculating.Add,
                '-' => Calculating.Subtract,
                '/' => Calculating.Divide,
                '*' => Calculating.Multiply,
                '#' => Calculating.Power,
                '%' => Calculating.Modulus,
                '|' => Calculating.Or,
                '^' => Calculating.Xor,
                // log exception
                _ => throw new NotSupportedException("The supplied operator is not supported")
            };
        }
    }
}