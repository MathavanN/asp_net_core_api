using AutoMapper;
using Supermarket.Core.Models;
using Supermarket.V1.Dtos.CategoryDtos;
using Supermarket.V1.Dtos.CountryDtos;

namespace Supermarket.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<CreateCategoryDto, Category>();

            CreateMap<CreateCountryDto, Country>();
        }
    }
}
