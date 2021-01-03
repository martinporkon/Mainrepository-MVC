using System;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Web.Facade.Baskets.BasketView
{
    public class BasketViewValidator : AbstractValidator<BasketView>
    {
        private readonly IStringLocalizer<BasketView> _localizer;// TODO localizer

        public BasketViewValidator(IStringLocalizer<BasketView> l)
        {
            _localizer = l;
            RuleFor(x => x.Description).NotEmpty()
                .WithMessage(x => l["Description not null"]);
            RuleFor(x => x.Name).Must(BeAValidPostCode)
                .WithErrorCode("Please specify a valid postcode");
            RuleFor(x => x.Id).NotEmpty();
        }

        private static bool BeAValidPostCode(string postCode)
        {
            /*var baz = GetMember.DisplayName(x => */
            throw new NotImplementedException();
        }
    }
}