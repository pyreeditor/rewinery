namespace Rewinery.Shared.TopicGroup.Answer.Response
{
    #pragma warning disable CS8618
    public class AnsResponseDto
    {
        /// <summary>
        /// Usenrame the user who wrote response
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Response text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Response created time
        /// </summary>
        public DateTime Created { get; set; }
    }
}
