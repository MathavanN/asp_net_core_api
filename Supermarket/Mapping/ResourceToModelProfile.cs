using AutoMapper;
using Supermarket.Core.Models;
using Supermarket.Resources;
using Supermarket.V1.Dtos.CategoryDtos;

namespace Supermarket.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<CreateCategoryDto, Category>();
        }
    }
}
