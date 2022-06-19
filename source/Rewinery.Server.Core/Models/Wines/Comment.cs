using Rewinery.Server.Core.Models.Base;

namespace Rewinery.Server.Core.Models.Wines
{
    #pragma warning disable CS8618
    public class Comment : BaseEntity
    {
        /// <summary>
        /// Information about the user who written the comment
        /// </summary>
        public ApplicationUser User { get; set; }

        /// <summary>
        /// Information about wine
        /// </summary>
        public Wine Wine { get; set; }

        /// <summary>
        /// Comment text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Collection of responces to this comment
        /// </summary>
        public ICollection<CommentResponse>? Responses { get; set; }

        /// <summary>
        /// Comment creation time
        /// </summary>
        public DateTime? Created { get; set; }
    }
}
