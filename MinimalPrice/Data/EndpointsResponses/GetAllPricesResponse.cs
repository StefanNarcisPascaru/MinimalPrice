namespace MinimalPrice.Data.EndpointsResponses
{
    public class GetAllPricesResponse
    {
        public IList<Price> Prices { get; set; } = new List<Price>();
    }
}
