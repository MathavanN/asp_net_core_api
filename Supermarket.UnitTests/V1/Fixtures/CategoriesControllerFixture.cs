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

        public CreateCategoryDto CreateCategoryDto { get; private set; }

        public CreateCategoryDto BadCreateCategoryDto { get; private set; }

        public Mock<IRepositoryWrapper> MockRepositoryWarapper { get; private set; }

        public IMapper MockMapper { get; private set; }
        public CategoriesControllerFixture()
        {
            MockRepositoryWarapper = new Mock<IRepositoryWrapper>();

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

            BadCreateCategoryDto = new CreateCategoryDto
            {
                Name = ""
            };
        }

        public void Dispose()
        {
            Categories = null;
            MockRepositoryWarapper = null;
            MockMapper = null;
            BadCreateCategoryDto = null;
        }
    }
}
