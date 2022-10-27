using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using MinimalPrice.Data.EndpointsResponses;
using MinimalPrice.Repositories;

namespace MinimalPrice.Endpoints.FastEndpoints
{
    [HttpGet("prices"), AllowAnonymous]
    public class GetAllPricesEndpoint : EndpointWithoutRequest<GetAllPricesResponse>
    {
        private readonly IPricesRepository _pricessRepository;
        public GetAllPricesEndpoint(IPricesRepository pricessRepository)
        {
            _pricessRepository = pricessRepository;
        }

        //public override void Configure()
        //{
        //    Get("/FromConfigurePrices");
        //    AllowAnonymous();
        //}

        public override void OnBeforeHandle(EmptyRequest req)
        {
            //there are some lifecicle events
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var prices = _pricessRepository.GetAll();

            var result = new GetAllPricesResponse()
            {
                Prices = prices
            };

            await SendOkAsync(result, ct);
        }
    }
}
