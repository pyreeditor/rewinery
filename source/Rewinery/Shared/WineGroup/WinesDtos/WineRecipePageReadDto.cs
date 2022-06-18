using AutoMapper;
using Rewinery.Shared.CommentGroup.WineCommentsDtos;
using Rewinery.Shared.WineGroup.GrapesDtos;
using Rewinery.Shared.WineGroup.IngredientsDtos;

namespace Rewinery.Shared.WineGroup.WinesDtos
{
    public class WineRecipePageReadDto : BaseDto
    {
#pragma warning disable CS8618
        public UserReadDto Owner { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Icon { get; set; }

        public GrapeReadDto Grape { get; set; }

        public List<IngredientReadDto> Ingredients { get; set; }

        public List<WineCommentReadDto>? Comments { get; set; }

#pragma warning restore CS8618
    }
}
