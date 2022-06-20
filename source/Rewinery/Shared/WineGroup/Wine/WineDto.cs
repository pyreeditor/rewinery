using Rewinery.Shared.WineGroup.Comment;
using Rewinery.Shared.WineGroup.Grape;
using Rewinery.Shared.WineGroup.Ingredient;

namespace Rewinery.Shared.WineGroup.Wine
{
#pragma warning disable CS8618
    public class WineDto : BaseDto
    {
        /// <summary>
        /// UserName the owner of the wine
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Wine name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the wine making process
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Price per liter of wine
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Wine icon
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Information about the grapes used to make wine
        /// </summary>
        public GrapeDto Grape { get; set; }

        /// <summary>
        /// List of ingredients that are part of the wine
        /// </summary>
        public List<IngredientDto> Inredients { get; set; }
        
        /// <summary>
        /// Wine comment list with response on comment
        /// </summary>
        public List<CommentDto>? Comments { get; set; }
    }
}
