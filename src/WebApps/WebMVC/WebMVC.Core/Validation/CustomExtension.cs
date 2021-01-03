using System.Collections.Generic;
using FluentValidation;

namespace WebMVC.Core.Validation
{
    public static class CustomExtension
    {
        public static IRuleBuilder<T1, T2> BeDifferentFrom<T1, T2>(this IRuleBuilder<T1, T2> ruleBuilder,
            string message)
            => ruleBuilder.Must(x => typeof(T2) != typeof(T1)).WithMessage(message);

        public static IRuleBuilderOptions<T, IList<TElement>> ListMustContainFewerThan<T, TElement>(this IRuleBuilder<T,
            IList<TElement>> ruleBuilder, int num)
            => ruleBuilder.Must(list => list.Count < num).WithMessage("The list contains too many items");

        // TODO description must be different from the title.
        // TODO author name must not be the same as the title.
        // validator.Validate(...);
    }
}