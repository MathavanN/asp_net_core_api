using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supermarket.ApiResponse;
using Supermarket.Core.Models;
using Supermarket.Core.Repositories.Contracts;
using Supermarket.V1.Dtos.CategoryDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;

        public CategoriesController(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetAllAsync()
        {
            var categories = await _repositoryWrapper.Category.ListAllCategoriesAsync();

            var categoryDtos = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categories);

            return Ok(categoryDtos);
        }

        [HttpGet("{id}", Name = "CategoryById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var dbCategory = await _repositoryWrapper.Category.FindByIdAsync(id);
            if (dbCategory == null)
                return NotFound(new NotFoundResponse("Category not found"));

            var categoryDto = _mapper.Map<Category, CategoryDto>(dbCategory);
            return Ok(categoryDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PostAsync([FromBody] CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<CreateCategoryDto, Category>(createCategoryDto);

            await _repositoryWrapper.Category.AddCategoryAsync(category);

            var categoryDto = _mapper.Map<Category, CategoryDto>(category);

            return CreatedAtRoute("CategoryById", new { id = categoryDto.Id }, categoryDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryDto saveCategoryDto)
        {
            var dbCategory = await _repositoryWrapper.Category.FindByIdAsync(id);
            if (dbCategory == null)
                return NotFound(new NotFoundResponse("Category not found"));

            dbCategory.Name = saveCategoryDto.Name;
            dbCategory.DateModified = saveCategoryDto.DateModified;

            await _repositoryWrapper.Category.UpdateCategoryAsync(dbCategory);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(NotFoundResponse), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var dbCategory = await _repositoryWrapper.Category.FindByIdAsync(id);
            if (dbCategory == null)
                return NotFound(new NotFoundResponse("Category not found"));

            await _repositoryWrapper.Category.DeleteCategoryAsync(dbCategory);

            return NoContent();
        }
    }
}