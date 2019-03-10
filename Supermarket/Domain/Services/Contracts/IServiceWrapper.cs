using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.Domain.Services.Contracts
{
    public interface IServiceWrapper
    {
        ICategoryService Category { get; }
        IProductService Product { get; }
    }
}
