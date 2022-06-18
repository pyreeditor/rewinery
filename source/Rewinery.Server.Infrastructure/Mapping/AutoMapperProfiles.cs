using AutoMapper;
using Rewinery.Server.Core.Models.Wines;
using Rewinery.Shared.WineGroup.Category;
using Rewinery.Shared.WineGroup.Comment;
using Rewinery.Shared.WineGroup.Comment.Response;
using Rewinery.Shared.WineGroup.Grape;
using Rewinery.Shared.WineGroup.Ingredient;
using Rewinery.Shared.WineGroup.Subcategory;
using Rewinery.Shared.WineGroup.Wine;
using Rewinery.Shared.WineGroup.WineRecipePage;

namespace Rewinery.Server.Infrastructure.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            #region wine-recipe-page-mapping
            CreateMap<Wine, ShortWineDto>()
                .ForMember(sgd => sgd.Owner,
                opt => opt.MapFrom(grape => grape.Owner.UserName));

            CreateMap<Grape, ShortGrapeDto>()
                .ForMember(sgd => sgd.Category,
                opt => opt.MapFrom(grape => grape.Category.Name))
                .ForMember(sgd => sgd.Subcategory,
                opt => opt.MapFrom(grape => grape.Subcategory.Name));

            CreateMap<Ingredient, ShortIngredientDto>();
            #endregion

            #region wine
            CreateMap<CreateWineDto, Wine>();

            CreateMap<Wine, WineDto>()
                .ForMember(wd => wd.Owner,
                opt => opt.MapFrom(wine => wine.Owner.UserName))
                .ForMember(wd => wd.Inredients,
                opt => opt.MapFrom(wine => wine.Ingredients))
                .ForMember(wd => wd.Comments,
                opt => opt.MapFrom(wine => wine.Comments));

            CreateMap<UpdateWineDto, Wine>();
            #endregion

            #region grape
            CreateMap<CreateGrapeDto, Grape>();

            CreateMap<Grape, GrapeDto>()
                .ForMember(gd => gd.Category,
                opt => opt.MapFrom(grape => grape.Category.Name))
                .ForMember(gd => gd.Subcategory,
                opt => opt.MapFrom(grape => grape.Subcategory.Name));

            CreateMap<UpdateGrapeDto, Grape>();
            #endregion

            #region category
            CreateMap<CreateCategoryDto, Category>();

            CreateMap<Category, CategoryDto>();

            CreateMap<CategoryDto, Category>();
            #endregion

            #region subcategory
            CreateMap<CreateSubcategoryDto, Subcategory>();

            CreateMap<Subcategory, SubcategoryDto>();

            CreateMap<SubcategoryDto, Subcategory>();
            #endregion

            #region ingredient
            CreateMap<CreateIngredientDto, Ingredient>();

            CreateMap<Ingredient, IngredientDto>();

            CreateMap<UpdateIngredientDto, Ingredient>();
            #endregion

            #region comment
            CreateMap<CreateCommentDto, Comment>();

            CreateMap<Comment, CommentDto>()
                .ForMember(crd => crd.User,
                opt => opt.MapFrom(comment => comment.User.UserName));

            CreateMap<UpdateCommentDto, Comment>();
            #endregion

            #region commentresponse
            CreateMap<CreateComResponseDto, CommentResponse>();

            CreateMap<CommentResponse, ComResponseDto>()
                .ForMember(crd => crd.User,
                opt => opt.MapFrom(response => response.User.UserName));

            CreateMap<UpdateCommentDto, CommentResponse>();
            #endregion

            #region topic

            #endregion
        }
    }
}
