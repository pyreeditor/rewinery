namespace Rewinery.Shared.WineGroup.Comment
{
#pragma warning disable CS8618
    public class CreateCommentDto
    {
        /// <summary>
        /// Username the user who wrote the comment
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// ID of the wine to which this comment belongs
        /// </summary>
        public int WineId { get; set; }

        /// <summary>
        /// Comment text
        /// </summary>
        public string Text { get; set; }
    }
}
