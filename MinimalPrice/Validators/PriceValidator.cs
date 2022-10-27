using FluentValidation;
using MinimalPrice.Data.EndpointsRequests;

namespace MinimalPrice.Validators
{
    public class PriceValidator : AbstractValidator<CreatePriceEndpointRequest>
    {
        public PriceValidator()
        {
            RuleFor(x => x.Product).NotNull().NotEmpty();
        }
    }
}
