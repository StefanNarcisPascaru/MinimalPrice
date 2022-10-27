namespace MinimalPrice.Data.EndpointsResponses
{
    public class CreatePriceEndpointResponse
    {
        public bool IsCreated { get; set; }

        public CreatePriceEndpointResponse(bool isCreated)
        {
            IsCreated = isCreated;
        }
    }
}
