using AutoMapper;
using Moq;
using Supermarket.Core.Models;
using Supermarket.Core.Repositories.Contracts;
using Supermarket.Mapping;
using Supermarket.V1.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;

namespace Supermarket.UnitTests.V1.Fixtures
{
    public class CategoriesControllerFixture : IDisposable
    {
        public IEnumerable<Category> Categories { get; private set; }

        public CreateCategoryDto CreateCategoryDto { get; set; }

        public SaveCategoryDto SaveCategoryDto { get; set; }

        public Mock<IRepositoryWrapper> MockRepositoryWrapper { get; private set; }

        public IMapper MockMapper { get; private set; }
        public CategoriesControllerFixture()
        {
            MockRepositoryWrapper = new Mock<IRepositoryWrapper>();

            //auto mapper configuration
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelToResourceProfile());
                cfg.AddProfile(new ResourceToModelProfile());
            });
            MockMapper = configuration.CreateMapper();

            Categories = new List<Category>
            {
                new Category{Id=1, Name="Apple", DateAdded=DateTime.Now, DateModified= DateTime.Now},
                new Category{Id=2, Name="Orange", DateAdded=DateTime.Now, DateModified= DateTime.Now},
                new Category{Id=3, Name="Mango", DateAdded=DateTime.Now, DateModified= DateTime.Now}
            };

            CreateCategoryDto = new CreateCategoryDto
            {
                Name = "Avocado"
            };

            SaveCategoryDto = new SaveCategoryDto
            {
                Name = "Blueberries"
            };
        }

        public void Dispose()
        {
            Categories = null;
            MockRepositoryWrapper = null;
            MockMapper = null;
            SaveCategoryDto = null;
            CreateCategoryDto = null;
        }
    }
}
