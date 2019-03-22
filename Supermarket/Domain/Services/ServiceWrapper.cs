using Supermarket.Core.Repositories.Contracts;
using Supermarket.Domain.Services.Contracts;

namespace Supermarket.Domain.Services
{
    public class ServiceWrapper : IServiceWrapper
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private ICategoryService _categoryService;
        private IProductService _productService;

        public ServiceWrapper(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public ICategoryService Category {
            get
            {
                if(_categoryService == null)
                {
                    _categoryService = new CategoryService(_repositoryWrapper);
                }

                return _categoryService;
            }
        }

        public IProductService Product
        {
            get
            {
                if(_productService == null)
                {
                    _productService = new ProductService(_repositoryWrapper);
                }

                return _productService;
            }
        }
    }
}
