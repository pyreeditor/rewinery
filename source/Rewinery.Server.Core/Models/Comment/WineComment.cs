using Rewinery.Server.Core.Models.Base;
using Rewinery.Server.Core.Models.Wines;

namespace Rewinery.Server.Core.Models.Comment
{
    public class WineComment : BaseEntity
    {
        #pragma warning disable CS8618
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
        public string Comment { get; set; }

        /// <summary>
        /// Collection of responces to this comment
        /// </summary>
        public ICollection<CommentResponse>? Responses { get; set; }
        #pragma warning restore CS8618
    }
}
