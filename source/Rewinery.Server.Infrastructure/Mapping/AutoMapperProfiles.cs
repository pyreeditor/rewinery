using AutoMapper;
using Rewinery.Server.Core.Models.Cellars;
using Rewinery.Server.Core.Models.Orders;
using Rewinery.Server.Core.Models.Topics;
using Rewinery.Server.Core.Models.Wines;
using Rewinery.Shared.CellarGroup.Cellar;
using Rewinery.Shared.CellarGroup.Rental;
using Rewinery.Shared.OrderGroup.Orders;
using Rewinery.Shared.OrderGroup.OrderStatus;
using Rewinery.Shared.TopicGroup.Answer;
using Rewinery.Shared.TopicGroup.Answer.Response;
using Rewinery.Shared.TopicGroup.Topic;
using Rewinery.Shared.TopicGroup.TopicPage;
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
            CreateMap<Comment, CommentDto>()
                .ForMember(cd => cd.User,
                opt => opt.MapFrom(comment => comment.User.UserName));

            CreateMap<UpdateCommentDto, Comment>();
            #endregion

            #region comment-response
            CreateMap<CommentResponse, ComResponseDto>()
                .ForMember(crd => crd.User,
                opt => opt.MapFrom(response => response.User.UserName));

            CreateMap<UpdateCommentDto, CommentResponse>();
            #endregion


            #region topic-page-mapping
            CreateMap<Topic, ShortTopicDto>()
                .ForMember(std => std.User,
                opt => opt.MapFrom(topic => topic.User.UserName));
            #endregion

            #region topic
            CreateMap<CreateTopicDto, Topic>();

            CreateMap<Topic, TopicDto>()
                .ForMember(td => td.User,
                opt => opt.MapFrom(topic => topic.User.UserName));

            CreateMap<UpdateTopicDto, Topic>();
            #endregion

            #region answer
            CreateMap<CreateAnswerDto, Answer>();

            CreateMap<Answer, AnswerDto>()
                .ForMember(ad => ad.User,
                opt => opt.MapFrom(answer => answer.User.UserName))
                .ForMember(ad => ad.Responses,
                opt => opt.MapFrom(answer => answer.AnswerResponces));

            CreateMap<UpdateAnswerDto, Answer>();
            #endregion

            #region answer-response
            CreateMap<CreateAnsResponseDto, AnswerResponse>();

            CreateMap<AnswerResponse, AnsResponseDto>()
                .ForMember(ard => ard.User,
                opt => opt.MapFrom(response => response.User.UserName));

            CreateMap<UpdateAnsResponseDto, AnswerResponse>();
            #endregion


            #region order
            CreateMap<CreateOrderDto, Order>();

            CreateMap<Order, OrderDto>()
                .ForMember(od => od.User,
                opt => opt.MapFrom(order => order.User.UserName));

            CreateMap<UpdateOrderDto, Order>();
            #endregion

            #region order-status
            CreateMap<CreateOrderStatusDto, OrderStatus>();

            CreateMap<OrderStatus, OrderStatusDto>();

            CreateMap<OrderStatusDto, OrderStatus>();
            #endregion


            #region cellar
            CreateMap<CreateCellarDto, Cellar>();

            CreateMap<Cellar, CellarDto>()
                .ForMember(cd => cd.Rental,
                opt => opt.MapFrom(cellar => cellar.CellarRental));

            CreateMap<UpdateCellarDto, Cellar>();
            #endregion

            #region cellar-rental
            CreateMap<CreateCellarRentalDto, CellarRental>();

            CreateMap<CellarRental, CellarRentalDto>()
                .ForMember(wd => wd.Owner,
                opt => opt.MapFrom(wine => wine.Owner.UserName))
                .ForMember(wd => wd.CellarName,
                opt => opt.MapFrom(wine => wine.Cellar.Name));

            CreateMap<UpdateCellarRentalDto, CellarRental>();
            #endregion
        }
    }
}
