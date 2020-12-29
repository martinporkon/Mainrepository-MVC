/*using System;
using System.Threading.Tasks;
using Sooduskorv_MVC.Aids.Computations;

namespace Sooduskorv_MVC.Aids.Extensions
{
    public static class Tasks
    {
        public static async Task<Maybe<TResult>> MapAsync<T, TResult>(this Maybe<T> option, Func<T, Task<TResult>> mapping)
        {
            if (mapping == null) throw new ArgumentNullException(nameof(mapping));

            foreach (var valueTask in option.Map(mapping))
            {
                if (valueTask == null) throw new InvalidOperationException($"{nameof(mapping)} must not return a null task.");

                var value = await valueTask.ConfigureAwait(continueOnCapturedContext: false);
                return value.Some();
            }

            return Maybe.None<TResult>();
        }
    }
}*/