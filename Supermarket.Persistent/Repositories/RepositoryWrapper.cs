using Supermarket.Persistent.Context;
using Supermarket.Persistent.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.Persistent.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _repositoryContext;
        private ICategoryRepository _categoryRepository;
        private IProductRepository _productRepository;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public ICategoryRepository Category
        {
            get
            {
                if(_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_repositoryContext);
                }

                return _categoryRepository;
            }
        }

        public IProductRepository Product
        {
            get
            {
                if(_productRepository == null)
                {
                    _productRepository = new ProductRepository(_repositoryContext);
                }

                return _productRepository;
            }
        }
    }
}
