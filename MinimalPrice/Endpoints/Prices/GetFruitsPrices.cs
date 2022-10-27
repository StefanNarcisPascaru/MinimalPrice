using MinimalPrice.Data;

namespace MinimalPrice.Endpoints.Prices
{
    public class GetFruitsPrices
    {
        public static Func<List<Price>> Handler(string? product)
        {
            var prices = new List<Price>(){
                new Price
                (
                    "orange",
                    22.2d,
                    "Eur"
                ),
                new Price
                (
                    "banana",
                    33.2d,
                    "Eur"
                ),

            };

            if (product != null)
            {
                return prices.Where(p => p.Product == product).ToList;
            }

            return () =>
            {
                return prices;
            };
        }

        public static async Task<Price?> GetByName(string product)
        {
            var prices = new List<Price>(){
                new Price
                (
                    "orange",
                    22.2d,
                    "Eur"
                ),
                new Price
                (
                    "banana",
                    33.2d,
                    "Eur"
                ),

            };

            return prices.FirstOrDefault(p => p.Product == product);
        }
    }
}
