using Supermarket.Domain.Communication;
using Supermarket.Domain.Services.Contracts;
using Supermarket.Entites.Models;
using Supermarket.Persistent.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CategoryService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            var dbCategory = await _repositoryWrapper.Category.FindById(id);
            if (dbCategory == null)
                return new CategoryResponse("Category not found");

            try
            {
                await _repositoryWrapper.Category.DeleteCategoryAsync(dbCategory);

                return new CategoryResponse(dbCategory);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _repositoryWrapper.Category.ListAllCategoriesAsync();
        }

        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _repositoryWrapper.Category.AddCategoryAsync(category);

                return new CategoryResponse(category);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            var dbCategory = await _repositoryWrapper.Category.FindById(id);
            if (dbCategory == null)
                return new CategoryResponse("Category not found");

            dbCategory.Name = category.Name;

            try
            {
                await _repositoryWrapper.Category.UpdateCategoryAsync(dbCategory);

                return new CategoryResponse(dbCategory);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }
    }
}
