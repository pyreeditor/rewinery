using AutoMapper;
using Rewinery.Server.Core.Models;
using Rewinery.Server.Core.Models.Comment;
using Rewinery.Server.Core.Models.Orders;
using Rewinery.Server.Core.Models.Topics;
using Rewinery.Server.Core.Models.Wines;
using Rewinery.Shared;
using Rewinery.Shared.CommentGroup.CommentResponsesDtos;
using Rewinery.Shared.CommentGroup.WineCommentsDtos;
using Rewinery.Shared.OrderGroup.OrdersDtos;
using Rewinery.Shared.OrderGroup.OrderStatusDtos;
using Rewinery.Shared.TopicGroup.AnswerResponsesDtos;
using Rewinery.Shared.TopicGroup.AnswersDtos;
using Rewinery.Shared.TopicGroup.TopicsDtos;
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

            CreateMap<Wine, WineRecipePageReadDto>();

            CreateMap<WineCreateDto, Wine>();

            CreateMap<ApplicationUser, UserReadDto>();


            CreateMap<Topic, ShortTopicInfoDto>()
                .ForMember(topicdto => topicdto.OwnerUserName,
                   opt => opt.MapFrom(topic => topic.User.UserName));

            CreateMap<Topic, TopicPageDto>()
            .ForMember(topicdto => topicdto.OwnerUserName,
                   opt => opt.MapFrom(topic => topic.User.UserName));

            CreateMap<TopicCreateDto, Topic>();

            CreateMap<Answer, AnswerReadDto>()
                .ForMember(answerReadDto => answerReadDto.OwnerUserName,
                   opt => opt.MapFrom(answer => answer.User.UserName))
                .ForMember(answerReadDto => answerReadDto.AnswerResponsesList,
                   opt => opt.MapFrom(answer => answer.AnswerResponces));

            CreateMap<AnswerResponse, AnswerResponseReadDto>()
                .ForMember(answerResponseReadDto => answerResponseReadDto.OwnerUserName,
                   opt => opt.MapFrom(answerResponse => answerResponse.User.UserName));

            CreateMap<AnswerCreateDto, Answer>();

            CreateMap<AnswerResponseCreateDto, AnswerResponse>();

            CreateMap<WineComment, WineCommentReadDto>()
                .ForMember(topicdto => topicdto.CommentOwnerUserName,
                   opt => opt.MapFrom(topic => topic.User.UserName))
                .ForMember(answerReadDto => answerReadDto.CommentResponsesList,
                   opt => opt.MapFrom(answer => answer.Responses));

            CreateMap<CommentResponse, CommentResponseReadDto>()
                .ForMember(topicdto => topicdto.OwnerUserName,
                   opt => opt.MapFrom(topic => topic.User.UserName));

            CreateMap<WineCommentCreateDto, WineComment>();

            CreateMap<CommentResponseCreateDto, CommentResponse>();

            CreateMap<OrderStatusCreateDto, OrderStatus>();

            CreateMap<OrderCreateDto, Order>();
        }
    }
}
