using MinimalPrice.Data;

namespace MinimalPrice.Repositories
{
    public class PricesRepository : IPricesRepository
    {
        private List<Price> prices = new List<Price>()
        {
            new(
                "orange",
                22.2d,
                "Eur"
            ),
            new(
                "banana",
                33.2d,
                "Eur"
            )
        };

        public IList<Price> GetAll()
        {
            return prices;
        }

        public bool Create(Price price)
        {
            prices.Add(price);
            return true;
        }

        public Price? GetByName(string reqProductName)
        {
            return prices.FirstOrDefault(p => p.Product == reqProductName);
        }
    }
}