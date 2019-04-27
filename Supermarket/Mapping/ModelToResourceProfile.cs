using AutoMapper;
using Supermarket.Core.Models;
using Supermarket.Extensions;
using Supermarket.V1.Dtos.AccountDtos;
using Supermarket.V1.Dtos.CategoryDtos;
using Supermarket.V1.Dtos.CountryDtos;
using Supermarket.V1.Dtos.ProductDtos;

namespace Supermarket.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<ApplicationUser, UserInfoDto>();

            CreateMap<Category, CategoryDto>();

            CreateMap<Product, ProductDto>()
                .ForMember(src => src.UnitOfMeasurement,
                            opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));

            CreateMap<Country, CountryDto>();
        }
    }
}
