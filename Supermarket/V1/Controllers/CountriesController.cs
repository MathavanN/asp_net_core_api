using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supermarket.ApiResponse;
using Supermarket.Core.Models;
using Supermarket.Core.Repositories.Contracts;
using Supermarket.V1.Dtos.CountryDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;

        public CountriesController(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var countries = await _repositoryWrapper.Country.ListAllCountriesAsync();

            var countriesDtos = _mapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(countries);

            return Ok(countriesDtos);
        }

        [HttpGet("{id}", Name = "CountryById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCountryById(int id)
        {
            var dbCountry = await _repositoryWrapper.Country.FindByIdAsync(id);
            if (dbCountry == null)
                return NotFound(new NotFoundResponse("Country not found"));

            var countryDto = _mapper.Map<Country, CountryDto>(dbCountry);

            return Ok(countryDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync([FromBody] CreateCountryDto createCountryDto)
        {
            var country = _mapper.Map<CreateCountryDto, Country>(createCountryDto);

            await _repositoryWrapper.Country.AddCountryAsync(country);

            var countryDto = _mapper.Map<Country, CountryDto>(country);

            return CreatedAtRoute("CountryById", new { id = countryDto.Id }, countryDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCountryDto saveCountryDto)
        {
            var dbCountry = await _repositoryWrapper.Country.FindByIdAsync(id);
            if (dbCountry == null)
                return NotFound(new NotFoundResponse("Country not found"));

            dbCountry.Name = saveCountryDto.Name;
            dbCountry.DateModified = saveCountryDto.DateModified;

            await _repositoryWrapper.Country.UpdateCountryAsync(dbCountry);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var dbCountry = await _repositoryWrapper.Country.FindByIdAsync(id);
            if (dbCountry == null)
                return NotFound(new NotFoundResponse("Country not found"));

            await _repositoryWrapper.Country.DeleteCountryAsync(dbCountry);

            return NoContent();
        }
    }
}