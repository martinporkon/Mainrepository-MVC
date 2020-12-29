using FluentValidation;
using WebMVC.Bff.HttpAggregator.Domain.DTO;

namespace WebMVC.Bff.HttpAggregator.Domain.Rules
{
    public class BasketDtoValidator : AbstractValidator<BasketDto>
    {
        public BasketDtoValidator()
        {
            
        }
    }
}