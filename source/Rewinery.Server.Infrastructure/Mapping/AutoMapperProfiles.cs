using AutoMapper;
using Rewinery.Server.Core.Models;
using Rewinery.Server.Core.Models.Wines;
using Rewinery.Shared;
using Rewinery.Shared.WineGroup.CategoriesDtos;
using Rewinery.Shared.WineGroup.GrapesDtos;
using Rewinery.Shared.WineGroup.IngredientsDtos;
using Rewinery.Shared.WineGroup.SubcategoriesDtos;
using Rewinery.Shared.WineGroup.WinesDtos;

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

            CreateMap<Wine, WineReadDto>();

            CreateMap<WineCreateDto, Wine>();

            CreateMap<ApplicationUser, UserReadDto>();



        }
    }
}
