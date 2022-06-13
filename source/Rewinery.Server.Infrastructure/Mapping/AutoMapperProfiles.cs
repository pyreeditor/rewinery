using AutoMapper;
using Rewinery.Server.Core.Models.Wines;
using Rewinery.Shared.Dtos.CategoriesDtos;
using Rewinery.Shared.Dtos.SubcategoriesDtos;


namespace Rewinery.Server.Infrastructure.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<SubcategoryCreateDto, Subcategory>();
            CreateMap<Subcategory, SubcategoryReadDto>();

            CreateMap<CategoryCreateDto, Category>();
            CreateMap<Category, CategoryReadDto>();

        }
    }
}
