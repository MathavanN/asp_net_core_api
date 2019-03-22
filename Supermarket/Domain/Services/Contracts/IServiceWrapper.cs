namespace Supermarket.Domain.Services.Contracts
{
    public interface IServiceWrapper
    {
        ICategoryService Category { get; }
        IProductService Product { get; }
    }
}
