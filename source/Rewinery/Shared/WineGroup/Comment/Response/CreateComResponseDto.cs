namespace Rewinery.Shared.WineGroup.Comment.Response
{
#pragma warning disable CS8618
    public class CreateComResponseDto
    {
        /// <summary>
        /// The ID of the comment on which it was made response
        /// </summary>
        public int CommentId { get; set; }

        /// <summary>
        /// Username the user who wrote the response
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Response text
        /// </summary>
        public string Text { get; set; }
    }
}
