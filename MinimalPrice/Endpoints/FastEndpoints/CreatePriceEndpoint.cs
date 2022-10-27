using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using MinimalPrice.Data;
using MinimalPrice.Data.EndpointsRequests;
using MinimalPrice.Data.EndpointsResponses;
using MinimalPrice.Repositories;

namespace MinimalPrice.Endpoints.FastEndpoints
{
    public class CreatePriceEndpoint : Endpoint<CreatePriceEndpointRequest, CreatePriceEndpointResponse>
    {
        private readonly IPricesRepository _pricessRepository;

        public CreatePriceEndpoint(IPricesRepository pricessRepository)
        {
            _pricessRepository = pricessRepository;
        }

        public override void Configure()
        {
            Post("prices/create");
            AllowAnonymous();
        }

        public override void OnValidationFailed()
        {
            //do some logging maybe
        }

        public override async Task HandleAsync(CreatePriceEndpointRequest req, CancellationToken ct)
        {
            var price = new Price(req.Product, req.Value, req.Currency);

            var response = new CreatePriceEndpointResponse(_pricessRepository.Create(price));
            await SendCreatedAtAsync<GetPriceForProduct>(new { productName = req.Product }, response, generateAbsoluteUrl: true, cancellation: ct);
        }
    }
}
