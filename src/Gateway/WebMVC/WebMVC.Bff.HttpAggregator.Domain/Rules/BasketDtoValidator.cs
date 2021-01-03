using FluentValidation;
using WebMVC.Bff.HttpAggregator.Domain.CatalogService.CommandHandlers;

namespace WebMVC.Bff.HttpAggregator.Domain.Rules
{
    public class BasketDtoValidator : AbstractValidator<BasketDto>
    {
        public BasketDtoValidator()
        {
            
        }
    }
}