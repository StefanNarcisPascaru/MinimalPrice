using MinimalPrice.Data;

namespace MinimalPrice.Repositories
{
    public interface IPricesRepository
    {
        IList<Price> GetAll();
        bool Create(Price price);
        Price? GetByName(string reqProductName);
    }
}
