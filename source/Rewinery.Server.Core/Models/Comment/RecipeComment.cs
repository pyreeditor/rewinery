using Rewinery.Server.Core.Models.Base;

namespace Rewinery.Server.Core.Models.Comment
{
    public class RecipeComment : BaseEntity
    {
        #pragma warning disable CS8618
        /// <summary>
        /// Information about the user who written the comment
        /// </summary>
        public ApplicationUser User { get; set; }

        /// <summary>
        /// Information about wine recepi
        /// </summary>
        public WineRecipe Recipe { get; set; }

        /// <summary>
        /// Comment text
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// Rating which was set by user
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Collection of responces to this comment
        /// </summary>
        public ICollection<CommentResponse> Responses { get; set; }
        #pragma warning restore CS8618
    }
}
