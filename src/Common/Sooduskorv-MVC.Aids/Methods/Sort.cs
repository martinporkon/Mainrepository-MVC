using System;

namespace Sooduskorv_MVC.Aids.Methods
{
    public static class Sort
    {
        public static void Upwards<T>(ref T min, ref T max) where T : IComparable
        {
            if (min.CompareTo(max) <= 0) return;
            var d = min;
            min = max;
            max = d;
        }
        public static void ToBackwards<T>(ref T max, ref T min) where T : notnull, IComparable
        {
            if (max.CompareTo(min) >= 0) return;
            var d = max;
            max = min;
            min = d;
        }
    }
}