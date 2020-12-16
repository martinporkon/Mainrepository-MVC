using System.ComponentModel.DataAnnotations;

namespace Sooduskorv_MVC.Common.Values
{
    public class LocationAttributeValidator : ValidationAttribute
    {
        public LocationAttributeValidator()
        {
            // TODO for Latitude and Longitude.
            // The location provided by the user must be a valid location.
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);// VALIDATE!
        }
    }
}