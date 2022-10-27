using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using MinimalPrice.Data.EndpointsRequests;
using MinimalPrice.Data.EndpointsResponses;
using MinimalPrice.Repositories;

namespace MinimalPrice.Endpoints.FastEndpoints
{
    [HttpGet("prices/{productName}"), AllowAnonymous]
    public class GetPriceForProduct : Endpoint<GetPriceForProductRequest, GetPriceForProductResponse>
    {
        private readonly IPricesRepository _pricessRepository;

        public GetPriceForProduct(IPricesRepository pricessRepository)
        {
            _pricessRepository = pricessRepository;
        }


        //public override void Configure()
        //{
        //    Get("prices/{productName}");
        //    AllowAnonymous();
        //}

        public override async Task HandleAsync(GetPriceForProductRequest req, CancellationToken ct)
        {
            var price = _pricessRepository.GetByName(req.ProductName);
            if (price == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            await SendOkAsync(new GetPriceForProductResponse(price), ct);
        }
    }
}
