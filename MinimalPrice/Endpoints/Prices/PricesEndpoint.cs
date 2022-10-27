using MinimalPrice.Data;

namespace MinimalPrice.Endpoints.Prices
{
    public static class PricesEndpoint
    {
        public static void AddEndpoints(IEndpointRouteBuilder routeBuilder)
        {
            routeBuilder.MapGet("/prices/fruits", GetFruitsPrices.Handler(null))
                .Produces<List<Price>>()
                .WithName("GetFruitsPrices")
                .WithTags("Getters");

            routeBuilder.MapGet("/prices/fruits/{product}", GetFruitsPrices.GetByName)
                .Produces<List<Price>>()
                .WithName("GetFruitPrices by name")
                .WithTags("Getters");
        }


    }
}
