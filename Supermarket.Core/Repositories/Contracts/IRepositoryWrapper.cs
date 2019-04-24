namespace Supermarket.Core.Repositories.Contracts
{
    public interface IRepositoryWrapper
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        ICountryRepository Country { get; }
    }
}
