namespace MinimalPrice.Data.EndpointsResponses
{
    public class GetPriceForProductResponse
    {
        public Price Price { get; set; }

        public GetPriceForProductResponse(Price price)
        {
            Price = price;
        }
    }
}
