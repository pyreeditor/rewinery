using AutoMapper;
using Rewinery.Server.Core.Models;
using Rewinery.Server.Core.Models.Wines;
using Rewinery.Shared.Dtos.CategoriesDtos;
using Rewinery.Shared.Dtos.GrapesDtos;
using Rewinery.Shared.Dtos.IngredientsDtos;
using Rewinery.Shared.Dtos.SubcategoriesDtos;
using Rewinery.Shared.Dtos.UsersDtos;
using Rewinery.Shared.Dtos.WineRecipesDtos;
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
                opt => opt.MapFrom(wine => wine.Grape.Category.Name))
                .ForMember(wineReadDto => wineReadDto.SubcategoryName,
                opt => opt.MapFrom(wine => wine.Grape.Subcategory.Name));

            CreateMap<WineCreateDto, Wine>();

            CreateMap<ApplicationUser, UserReadDto>();

            CreateMap<WineRecipe, WineRecipeReadDto>()
                .ForMember(winerecipeReadDto => winerecipeReadDto.Id,
                opt => opt.MapFrom(winerecipe => winerecipe.Id))
                .ForMember(winerecipeReadDto => winerecipeReadDto.OwnerFirstName,
                opt => opt.MapFrom(winerecipe => winerecipe.Owner.FirstName))
                .ForMember(winerecipeReadDto => winerecipeReadDto.OwnerLastName,
                opt => opt.MapFrom(winerecipe => winerecipe.Owner.LastName))
                .ForMember(winerecipeReadDto => winerecipeReadDto.OwnerUserName,
                opt => opt.MapFrom(winerecipe => winerecipe.Owner.UserName))
                .ForMember(winerecipeReadDto => winerecipeReadDto.Icon,
                opt => opt.MapFrom(winerecipe => winerecipe.Icon))
                .ForMember(winerecipeReadDto => winerecipeReadDto.Public,
                opt => opt.MapFrom(winerecipe => winerecipe.Public))
                .ForMember(winerecipeReadDto => winerecipeReadDto.Price,
                opt => opt.MapFrom(winerecipe => winerecipe.Wine.Price))
                .ForMember(winerecipeReadDto => winerecipeReadDto.CategoryName,
                opt => opt.MapFrom(winerecipe => winerecipe.Wine.Grape.Category.Name))
                .ForMember(winerecipeReadDto => winerecipeReadDto.SubcategoryName,
                opt => opt.MapFrom(winerecipe => winerecipe.Wine.Grape.Subcategory.Name))
                .ForMember(winerecipeReadDto => winerecipeReadDto.GrapeName,
                opt => opt.MapFrom(winerecipe => winerecipe.Wine.Grape.Name))
                .ForMember(winerecipeReadDto => winerecipeReadDto.Description,
                opt => opt.MapFrom(winerecipe => winerecipe.Wine.Description))
                .ForMember(winerecipeReadDto => winerecipeReadDto.WineName,
                opt => opt.MapFrom(winerecipe => winerecipe.Wine.Name))
                ;


        }
    }
}
