using Rewinery.Server.Core.Models.Base;

namespace Rewinery.Server.Core.Models.Wines
{
#pragma warning disable CS8618
    public class CommentResponse : BaseEntity
    {
        /// <summary>
        /// Information about user comment for wine recipe
        /// </summary>
        public Comment Comment { get; set; }

        /// <summary>
        /// Information about the user who written the responce to comment
        /// </summary>
        public ApplicationUser User { get; set; }

        /// <summary>
        /// Text of comment responce
        /// </summary>
        public string Text { get; set; }

        public DateTime? Created { get; set; }
    }
}
