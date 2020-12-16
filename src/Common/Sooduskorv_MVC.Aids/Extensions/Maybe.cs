using Sooduskorv_MVC.Aids.Computations;

namespace Sooduskorv_MVC.Aids.Extensions
{
    public static class Maybe
    {
        public static Maybe<T> Some<T>(T value) => new Maybe<T>(value, true);
        public static Maybe<T> None<T>(this T value) => None<T>();
        public static Maybe<T> None<T>() => new Maybe<T>(default(T), false);
    }
}