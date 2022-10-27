namespace MinimalPrice.Data.EndpointsRequests
{
    public class CreatePriceEndpointRequest
    {
        public string Product { get; set; }
        public double Value { get; set; }
        public string Currency { get; set; }
    }
}
