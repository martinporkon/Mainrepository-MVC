using System;
using System.ComponentModel.DataAnnotations;

namespace Sooduskorv_MVC.Common.Validation
{
    /*public class EmailDomainValidator : AbstractValidator<EmailView>
    {
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return base.Validate(validationContext);
        }
    }

    public class EmailView
    {
        public string Email { get; set; }
    }*/
    public class EmailDomainValidator : ValidationAttribute
    {
        public string AllowedDomain { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext v)
        {
            var strings = value.ToString().Split('@');
            return string.Equals(strings[1], AllowedDomain,
                StringComparison.CurrentCultureIgnoreCase) ?
                null : new ValidationResult(ErrorMessage,
                    new[] { v.MemberName });
        }
    }

}