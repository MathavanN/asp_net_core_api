using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Supermarket.Core.Models;
using Supermarket.UnitTests.V1.Fixtures;
using Supermarket.V1.Controllers;
using Supermarket.V1.Dtos.CategoryDtos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace Supermarket.UnitTests.V1
{
    public class CategoriesControllerTest : IClassFixture<CategoriesControllerFixture>
    {
        readonly CategoriesControllerFixture _fixture;

        public CategoriesControllerTest(CategoriesControllerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async void Task_GetAllAsync_ReturnsOkObjectResult()
        {
            //Arrange
            _fixture.MockRepositoryWrapper.Setup(x => x.Category.ListAllCategoriesAsync()).ReturnsAsync(_fixture.Categories);

            var categoriesController = new CategoriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);

            //Act
            var result = await categoriesController.GetAllAsync();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Task_GetAllAsync_ReturnsAll()
        {
            //Arrange
            _fixture.MockRepositoryWrapper.Setup(x => x.Category.ListAllCategoriesAsync()).ReturnsAsync(_fixture.Categories);

            var categoriesController = new CategoriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);

            //Act
            var result = await categoriesController.GetAllAsync();

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var categories = okResult.Value.Should().BeAssignableTo<IEnumerable<CategoryDto>>().Subject.ToList();

            categories.Count().Should().Be(3);
            Assert.Equal("Apple", categories[0].Name);
            Assert.Equal("Orange", categories[1].Name);
            Assert.Equal("Mango", categories[2].Name);
        }

        [Fact]
        public async void Task_GetCategoryById_ReturnsOkObjectResult()
        {
            //Arrange
            var categoryId = 1;
            _fixture.MockRepositoryWrapper.Setup(x => x.Category.FindByIdAsync(categoryId)).ReturnsAsync(_fixture.Categories.ToList()[0]);

            var categoriesController =
                new CategoriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);

            //Act
            var result = await categoriesController.GetCategoryById(categoryId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Task_GetCategoryById_ReturnsNotFoundResult()
        {
            //Arrange
            var categoryId = 1;
            _fixture.MockRepositoryWrapper.Setup(x => x.Category.FindByIdAsync(categoryId)).ReturnsAsync(_fixture.Categories.ToList()[0]);

            var categoriesController = new CategoriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);
            categoryId = 5;
            //Act
            var result = await categoriesController.GetCategoryById(categoryId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async void Task_GetCategoryById_ReturnsMatchResult()
        {
            //Arrange
            var categoryId = 2;
            _fixture.MockRepositoryWrapper.Setup(x => x.Category.FindByIdAsync(categoryId)).ReturnsAsync(_fixture.Categories.ToList()[1]);

            var categoriesController = new CategoriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);

            //Act
            var result = await categoriesController.GetCategoryById(categoryId);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var category = okResult.Value.Should().BeAssignableTo<CategoryDto>().Subject;

            Assert.Equal("Orange", category.Name);
        }

        [Fact]
        public async void Task_PostAsync_ReturnsCreatedAtRouteResult()
        {
            //Arrange
            _fixture.MockRepositoryWrapper.Setup(x => x.Category.AddCategoryAsync(_fixture.MockMapper.Map<CreateCategoryDto, Category>(_fixture.CreateCategoryDto)));

            var categoriesController = new CategoriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);

            //Act
            var result = await categoriesController.PostAsync(_fixture.CreateCategoryDto);

            // Assert
            Assert.IsType<CreatedAtRouteResult>(result);
        }

        [Fact]
        public void Task_PostAsync_ReturnsBadRequestResult_FieldRequired()
        {
            //Arrange
            _fixture.CreateCategoryDto.Name = "";
            var validationContext = new ValidationContext(_fixture.CreateCategoryDto, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(_fixture.CreateCategoryDto, validationContext, validationResults);

            var categoriesController = new CategoriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);

            //Act
            foreach (var validationResult in validationResults)
            {
                categoriesController.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }

            // Assert
            Assert.False(categoriesController.ModelState.IsValid);
            Assert.Equal(1, categoriesController.ModelState.ErrorCount);
            Assert.True(categoriesController.ModelState.ContainsKey("Name"));
            Assert.Equal("The Name field is required.", categoriesController.ModelState.First().Value.Errors[0].ErrorMessage, true);
        }

        [Fact]
        public void Task_PostAsync_ReturnsBadRequestResult_FieldLength()
        {
            //Arrange
            _fixture.CreateCategoryDto.Name = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
            var validationContext = new ValidationContext(_fixture.CreateCategoryDto, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(_fixture.CreateCategoryDto, validationContext, validationResults, true);

            var categoriesController = new CategoriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);

            //Act
            foreach (var validationResult in validationResults)
            {
                categoriesController.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }

            // Assert
            Assert.False(categoriesController.ModelState.IsValid);
            Assert.Equal(1, categoriesController.ModelState.ErrorCount);
            Assert.True(categoriesController.ModelState.ContainsKey("Name"));
            categoriesController.ModelState.First().Value.Errors[0].ErrorMessage.Contains("maximum length of '30'").Should().BeTrue();
        }

        [Fact]
        public async void Task_PutAsync_ReturnsNoContentResult()
        {
            //Arrange
            var categoryId = 1;
            _fixture.MockRepositoryWrapper.Setup(x => x.Category.FindByIdAsync(categoryId)).ReturnsAsync(_fixture.Categories.ToList()[0]);

            var categoriesController = new CategoriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);

            //Act
            var result = await categoriesController.PutAsync(categoryId, _fixture.SaveCategoryDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void Task_PutAsync_ReturnsNotFoundResult()
        {
            //Arrange
            var categoryId = 1;
            _fixture.MockRepositoryWrapper.Setup(x => x.Category.FindByIdAsync(categoryId)).ReturnsAsync(_fixture.Categories.ToList()[0]);

            var categoriesController = new CategoriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);
            categoryId = 5;

            //Act
            var result = await categoriesController.PutAsync(categoryId, _fixture.SaveCategoryDto);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void Task_PutAsync_ReturnsBadRequestResult_FieldRequired()
        {
            //Arrange
            _fixture.SaveCategoryDto.Name = "";
            var validationContext = new ValidationContext(_fixture.SaveCategoryDto, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(_fixture.SaveCategoryDto, validationContext, validationResults);

            var categoriesController = new CategoriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);

            //Act
            foreach (var validationResult in validationResults)
            {
                categoriesController.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }

            // Assert
            Assert.False(categoriesController.ModelState.IsValid);
            Assert.Equal(1, categoriesController.ModelState.ErrorCount);
            Assert.True(categoriesController.ModelState.ContainsKey("Name"));
            Assert.Equal("The Name field is required.", categoriesController.ModelState.First().Value.Errors[0].ErrorMessage, true);
        }

        [Fact]
        public void Task_PutAsync_ReturnsBadRequestResult_FieldLength()
        {
            //Arrange
            _fixture.SaveCategoryDto.Name = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
            var validationContext = new ValidationContext(_fixture.SaveCategoryDto, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(_fixture.SaveCategoryDto, validationContext, validationResults, true);

            var categoriesController = new CategoriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);

            //Act
            foreach (var validationResult in validationResults)
            {
                categoriesController.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }

            // Assert
            Assert.False(categoriesController.ModelState.IsValid);
            Assert.Equal(1, categoriesController.ModelState.ErrorCount);
            Assert.True(categoriesController.ModelState.ContainsKey("Name"));
            categoriesController.ModelState.First().Value.Errors[0].ErrorMessage.Contains("maximum length of '30'").Should().BeTrue();
        }

        [Fact]
        public async void Task_DeleteAsync_ReturnsNoContentResult()
        {
            //Arrange
            var categoryId = 1;
            _fixture.MockRepositoryWrapper.Setup(x => x.Category.FindByIdAsync(categoryId)).ReturnsAsync(_fixture.Categories.ToList()[0]);

            var categoriesController = new CategoriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);

            //Act
            var result = await categoriesController.DeleteAsync(categoryId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void Task_DeleteAsync_ReturnsNotFoundResult()
        {
            //Arrange
            var categoryId = 1;
            _fixture.MockRepositoryWrapper.Setup(x => x.Category.FindByIdAsync(categoryId)).ReturnsAsync(_fixture.Categories.ToList()[0]);

            var categoriesController = new CategoriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);
            categoryId = 5;

            //Act
            var result = await categoriesController.DeleteAsync(categoryId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
