using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Core.Models;
using Supermarket.Core.Repositories.Contracts;
using Supermarket.Resources;
using Supermarket.V1.Dtos.ProductDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;

        public ProductsController(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _repositoryWrapper.Product.ListAllProductsAsync();

            var productDtos = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);

            return Ok(productDtos);
        }
    }
}