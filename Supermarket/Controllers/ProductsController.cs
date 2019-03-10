using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Domain.Services.Contracts;
using Supermarket.Entites.Models;
using Supermarket.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.Controllers
{
    [Route("/api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceWrapper _serviceWrapper;
        private readonly IMapper _mapper;

        public ProductsController(IServiceWrapper serviceWrapper, IMapper mapper)
        {
            _serviceWrapper = serviceWrapper;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _serviceWrapper.Product.ListAsync();

            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

            return Ok(resources);
        }
    }
}