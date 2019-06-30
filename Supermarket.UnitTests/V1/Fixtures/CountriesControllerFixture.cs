using AutoMapper;
using Moq;
using Supermarket.Core.Models;
using Supermarket.Core.Repositories.Contracts;
using Supermarket.Mapping;
using Supermarket.V1.Dtos.CountryDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.UnitTests.V1.Fixtures
{
    public class CountriesControllerFixture : IDisposable
    {

        public IEnumerable<Country> Countries { get; private set; }

        public CreateCountryDto CreateCountryDto { get; set; }

        public SaveCountryDto SaveCountryDto { get; set; }

        public Mock<IRepositoryWrapper> MockRepositoryWrapper { get; private set; }

        public IMapper MockMapper { get; set; }

        public CountriesControllerFixture()
        {
            MockRepositoryWrapper = new Mock<IRepositoryWrapper>();

            //auto mapper configuration
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelToResourceProfile());
                cfg.AddProfile(new ResourceToModelProfile());
            });
            MockMapper = configuration.CreateMapper();

            Countries = new List<Country>
            {
                new Country{ Id = 1, Name = "Singapore", DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Country{ Id = 2, Name = "Sri Lanka", DateAdded = DateTime.Now, DateModified = DateTime.Now },
                new Country{ Id = 3, Name = "India", DateAdded = DateTime.Now, DateModified = DateTime.Now },
            };

            CreateCountryDto = new CreateCountryDto
            {
                Name = "China"
            };

            SaveCountryDto = new SaveCountryDto
            {
                Name = "Australia"
            };
        }
        public void Dispose()
        {
            Countries = null;
            MockRepositoryWrapper = null;
            MockMapper = null;
            CreateCountryDto = null;
            SaveCountryDto = null;
        }
    }
}
