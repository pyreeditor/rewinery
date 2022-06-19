using Rewinery.Shared.WineGroup.Comment.Response;

namespace Rewinery.Shared.WineGroup.Comment
{
    #pragma warning disable CS8618
    public class CommentDto : BaseDto
    {
        /// <summary>
        /// Comment owner user name
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Comment text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// List of response to comment
        /// </summary>
        public List<ComResponseDto> Responses { get; set; }

        /// <summary>
        /// Comment created time
        /// </summary>
        public DateTime Created { get; set; }
    }
}
