using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Supermarket.Core.Models;
using Supermarket.UnitTests.V1.Fixtures;
using Supermarket.V1.Controllers;
using Supermarket.V1.Dtos.CountryDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace Supermarket.UnitTests.V1
{
    public class CountriesControllerTest : IClassFixture<CountriesControllerFixture>
    {
        readonly CountriesControllerFixture _fixture;

        public CountriesControllerTest(CountriesControllerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async void Task_GetAllAsync_ReturnsOkObjectResult()
        {
            //Arrange
            _fixture.MockRepositoryWrapper.Setup(x => x.Country.ListAllCountriesAsync()).ReturnsAsync(_fixture.Countries);

            var countriesController = new CountriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);

            //Act
            var result = await countriesController.GetAllAsync();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Task_GetAllAsync_ReturnsAll()
        {
            //Arrange
            _fixture.MockRepositoryWrapper.Setup(x => x.Country.ListAllCountriesAsync()).ReturnsAsync(_fixture.Countries);

            var countriesController = new CountriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);

            //Act
            var result = await countriesController.GetAllAsync();

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var countries = okResult.Value.Should().BeAssignableTo<IEnumerable<CountryDto>>().Subject.ToList();

            countries.Count().Should().Be(3);
            Assert.Equal("Singapore", countries[0].Name);
            Assert.Equal("Sri Lanka", countries[1].Name);
            Assert.Equal("India", countries[2].Name);
        }

        [Fact]
        public async void Task_GetCountryById_ReturnsOkObjectResult()
        {
            //Arrange
            var countryId = 1;
            _fixture.MockRepositoryWrapper.Setup(x => x.Country.FindByIdAsync(countryId)).ReturnsAsync(_fixture.Countries.ToList()[0]);

            var countriesController = new CountriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);

            //Act
            var result = await countriesController.GetCountryById(countryId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Task_GetCountryById_ReturnsNotFoundResult()
        {
            //Arrange
            var countryId = 1;
            _fixture.MockRepositoryWrapper.Setup(x => x.Country.FindByIdAsync(countryId)).ReturnsAsync(_fixture.Countries.ToList()[0]);

            var countriesController = new CountriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);
            countryId = 5;
            //Act
            var result = await countriesController.GetCountryById(countryId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async void Task_GetCountryById_ReturnsMatchResult()
        {
            //Arrange
            var countryId = 2;
            _fixture.MockRepositoryWrapper.Setup(x => x.Country.FindByIdAsync(countryId)).ReturnsAsync(_fixture.Countries.ToList()[1]);

            var countriesController = new CountriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);

            //Act
            var result = await countriesController.GetCountryById(countryId);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var country = okResult.Value.Should().BeAssignableTo<CountryDto>().Subject;

            Assert.Equal("Sri Lanka", country.Name);
        }

        [Fact]
        public async void Task_PostAsync_ReturnsCreatedAtRouteResult()
        {
            //Arrange
            _fixture.MockRepositoryWrapper.Setup(x => x.Country.AddCountryAsync(_fixture.MockMapper.Map<CreateCountryDto, Country>(_fixture.CreateCountryDto)));

            var countriesController = new CountriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);

            //Act
            var result = await countriesController.PostAsync(_fixture.CreateCountryDto);

            // Assert
            Assert.IsType<CreatedAtRouteResult>(result);
        }

        [Fact]
        public void Task_PostAsync_ReturnsBadRequestResult_FieldRequired()
        {
            //Arrange
            _fixture.CreateCountryDto.Name = "";
            var validationContext = new ValidationContext(_fixture.CreateCountryDto, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(_fixture.CreateCountryDto, validationContext, validationResults);

            var countriesController = new CountriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);

            //Act
            foreach (var validationResult in validationResults)
            {
                countriesController.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }

            // Assert
            Assert.False(countriesController.ModelState.IsValid);
            Assert.Equal(1, countriesController.ModelState.ErrorCount);
            Assert.True(countriesController.ModelState.ContainsKey("Name"));
            Assert.Equal("The Name field is required.", countriesController.ModelState.First().Value.Errors[0].ErrorMessage, true);
        }

        [Fact]
        public void Task_PostAsync_ReturnsBadRequestResult_FieldLength()
        {
            //Arrange
            _fixture.CreateCountryDto.Name = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
            var validationContext = new ValidationContext(_fixture.CreateCountryDto, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(_fixture.CreateCountryDto, validationContext, validationResults, true);

            var countriesController = new CountriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);

            //Act
            foreach (var validationResult in validationResults)
            {
                countriesController.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }

            // Assert
            Assert.False(countriesController.ModelState.IsValid);
            Assert.Equal(1, countriesController.ModelState.ErrorCount);
            Assert.True(countriesController.ModelState.ContainsKey("Name"));
            countriesController.ModelState.First().Value.Errors[0].ErrorMessage.Contains("maximum length of '30'").Should().BeTrue();
        }

        [Fact]
        public async void Task_PutAsync_ReturnsNoContentResult()
        {
            //Arrange
            var countryId = 1;
            _fixture.MockRepositoryWrapper.Setup(x => x.Country.FindByIdAsync(countryId)).ReturnsAsync(_fixture.Countries.ToList()[0]);

            var countriesController = new CountriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);

            //Act
            var result = await countriesController.PutAsync(countryId, _fixture.SaveCountryDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void Task_PutAsync_ReturnsNotFoundResult()
        {
            //Arrange
            var countryId = 1;
            _fixture.MockRepositoryWrapper.Setup(x => x.Country.FindByIdAsync(countryId)).ReturnsAsync(_fixture.Countries.ToList()[0]);

            var countriesController = new CountriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);
            countryId = 5;

            //Act
            var result = await countriesController.PutAsync(countryId, _fixture.SaveCountryDto);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void Task_PutAsync_ReturnsBadRequestResult_FieldRequired()
        {
            //Arrange
            _fixture.SaveCountryDto.Name = "";
            var validationContext = new ValidationContext(_fixture.SaveCountryDto, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(_fixture.SaveCountryDto, validationContext, validationResults);

            var countriesController = new CountriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);

            //Act
            foreach (var validationResult in validationResults)
            {
                countriesController.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }

            // Assert
            Assert.False(countriesController.ModelState.IsValid);
            Assert.Equal(1, countriesController.ModelState.ErrorCount);
            Assert.True(countriesController.ModelState.ContainsKey("Name"));
            Assert.Equal("The Name field is required.", countriesController.ModelState.First().Value.Errors[0].ErrorMessage, true);
        }

        [Fact]
        public void Task_PutAsync_ReturnsBadRequestResult_FieldLength()
        {
            //Arrange
            _fixture.SaveCountryDto.Name = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
            var validationContext = new ValidationContext(_fixture.SaveCountryDto, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(_fixture.SaveCountryDto, validationContext, validationResults, true);

            var countriesController = new CountriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);

            //Act
            foreach (var validationResult in validationResults)
            {
                countriesController.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }

            // Assert
            Assert.False(countriesController.ModelState.IsValid);
            Assert.Equal(1, countriesController.ModelState.ErrorCount);
            Assert.True(countriesController.ModelState.ContainsKey("Name"));
            countriesController.ModelState.First().Value.Errors[0].ErrorMessage.Contains("maximum length of '30'").Should().BeTrue();
        }

        [Fact]
        public async void Task_DeleteAsync_ReturnsNoContentResult()
        {
            //Arrange
            var countryId = 1;
            _fixture.MockRepositoryWrapper.Setup(x => x.Country.FindByIdAsync(countryId)).ReturnsAsync(_fixture.Countries.ToList()[0]);

            var countriesController = new CountriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);

            //Act
            var result = await countriesController.DeleteAsync(countryId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async void Task_DeleteAsync_ReturnsNotFoundResult()
        {
            //Arrange
            var countryId = 1;
            _fixture.MockRepositoryWrapper.Setup(x => x.Country.FindByIdAsync(countryId)).ReturnsAsync(_fixture.Countries.ToList()[0]);

            var countriesController = new CountriesController(_fixture.MockRepositoryWrapper.Object, _fixture.MockMapper);
            countryId = 5;

            //Act
            var result = await countriesController.DeleteAsync(countryId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
