namespace Rewinery.Shared.WineGroup.Comment.Response
{
    #pragma warning disable CS8618
    public class ComResponseDto
    {
        /// <summary>
        /// Response owner user name
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Responce text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Response created time
        /// </summary>
        public DateTime Created { get; set; }
    }
}