using AutoMapper;
using Rewinery.Server.Core.Models.Wines;
using Rewinery.Shared.Dtos.CategoriesDtos;
using Rewinery.Shared.Dtos.GrapesDtos;
using Rewinery.Shared.Dtos.IngredientsDtos;
using Rewinery.Shared.Dtos.SubcategoriesDtos;
using Rewinery.Shared.Dtos.WinesDtos;

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

            CreateMap<Grape, GrapeReadDto>();
            CreateMap<GrapeCreateDto, Grape>();

            CreateMap<Ingredient, IngredientReadDto>();
            CreateMap<IngredientCreateDto, Ingredient>();

            CreateMap<Wine, WineReadDto>()
                .ForMember(wineReadDto => wineReadDto.Id,
                   opt => opt.MapFrom(wine => wine.Id))
                .ForMember(wineReadDto => wineReadDto.GrapeName,
                opt => opt.MapFrom(wine => wine.Grape.Name))
                .ForMember(wineReadDto => wineReadDto.CategoryName,
                opt => opt.MapFrom(wine => wine.Grape.Category.Name));
            
            CreateMap<WineCreateDto, Wine>();

        }
    }
}
