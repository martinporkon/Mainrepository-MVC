using System;
using System.Collections.Generic;
using System.Linq;
using Sooduskorv_MVC.Aids.Methods;

namespace Sooduskorv_MVC.Aids.Extensions
{
    public static class Lists
    {
        public static IEnumerable<T> OrderBy<T>(IEnumerable<T> list, Func<T, string> func)
            => Safe.Run(
                () => list.OrderBy(func), ((new List<T>()) as IEnumerable<T>), true);

        public static IEnumerable<T> Distinct<T>(IEnumerable<T> list)
            => Safe.Run(list.Distinct, new List<T>(), true);

        public static void Remove<T>(this IList<T> list, Type type)
            => Safe.Run(
                () => list.Where(x => x.GetType() == type).ToList()
                    .ForEach(obj => list.Remove(obj)), true);

        public static IEnumerable<TTo> Convert<TFrom, TTo>(IEnumerable<TFrom> list,
            Func<TFrom, TTo> func) => Safe.Run(() => list.Select(func),
                new List<TTo>(), true);
    }
}