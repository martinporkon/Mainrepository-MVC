using System;
using System.ComponentModel;
using Sooduskorv_MVC.Aids.Methods;

namespace Sooduskorv_MVC.Aids.Extensions
{

    public static class Variable
    {

        public static string ToString<T>(T v)
            => Safe.Run(
                () => v?.ToString() ?? string.Empty,
                string.Empty);

        public static T TryParse<T>(string s)
            => Safe.Run(() =>
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));

                return (T)converter.ConvertFromString(s);
            }, default(T));

        public static object TryParse(string s, Type t)
            => Safe.Run(() =>
            {
                var converter = TypeDescriptor.GetConverter(t);

                return converter.ConvertFromString(s);
            }, default);

    }

}