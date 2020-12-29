using FluentValidation;
using WebMVC.Bff.HttpAggregator.Domain.DTO;

namespace WebMVC.Bff.HttpAggregator.Domain.Rules
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            
        }
    }
}