using Rewinery.Server.Core.Models.Base;
using Rewinery.Server.Core.Models.Comment;
using Rewinery.Server.Core.Models.Wines;

namespace Rewinery.Server.Core.Models
{
    public class WineRecipe : BaseEntity
    {
        #pragma warning disable CS8618
        /// <summary>
        /// Information about the user who owns this recipe
        /// </summary>
        public ApplicationUser Owner { get; set; }

        /// <summary>
        /// Availability of the wine recipe (This recipe is available to everyone or private)
        /// </summary>
        public bool Public { get; set; }

        /// <summary>
        /// Recipe wine icon
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Information about wine
        /// </summary>
        public Wine Wine { get; set; }

        /// <summary>
        /// Collection of the comment to this recipe
        /// </summary>
        public ICollection<RecipeComment>? Comments { get; set; }
        #pragma warning restore CS8618
    }
}
