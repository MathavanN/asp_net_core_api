using Supermarket.Core.Models;
using Supermarket.Core.Repositories;
using Supermarket.UnitTests.Supermarket.Core.Fixtures;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Supermarket.UnitTests.Supermarket.Core.Repositories
{
    public class CategoryRepositoryTests : IClassFixture<InMemoryRepositoryContextFixture>
    {
        private readonly InMemoryRepositoryContextFixture _fixture;

        public CategoryRepositoryTests(InMemoryRepositoryContextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async void Task_AddCategoryAsync_ShouldAddNewCategories()
        {
            //// Arrange 
            //var categories = new List<Category>
            //{
            //    new Category{ Id=1, Name="Apple", DateAdded=DateTime.Now, DateModified= DateTime.Now },
            //    new Category{ Id=2, Name="Orange", DateAdded=DateTime.Now, DateModified= DateTime.Now },
            //    new Category{ Id=3, Name="Mango", DateAdded=DateTime.Now, DateModified= DateTime.Now }
            //};
            //var categoryRepository = new CategoryRepository(_fixture.RepositoryContext);

            ////Act
            //foreach(var category in categories)
            //{
            //    await categoryRepository.AddCategoryAsync(category);
            //}
            
            //await AddAsync(category);
            //await SaveAsync();
        }
    }
}
