using System;
using System.Collections.Generic;
using System.Text;
using Basket.Facade;
using FluentValidation;

namespace Basket.Domain.Rules
{
    public class CustomerValidator : AbstractValidator<CustomerView>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Please specify a first name");
            RuleFor(x => x.Id).NotEqual(0);
            RuleFor(x => x.Address).Length(20, 250);
            RuleFor(x => x.PostCode).Must(BeAValidPostcode).WithMessage("Please specify a valid postcode");
        }

        private static bool BeAValidPostcode(string postcode)
        {
            // custom postcode validating logic goes here
            return false;
        }
    }
}