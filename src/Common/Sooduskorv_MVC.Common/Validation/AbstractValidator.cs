using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sooduskorv_MVC.Common.Validation
{
    public abstract class AbstractValidator<T> : IValidatableObject where T : class
    {
        protected AbstractValidator()
        {
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}