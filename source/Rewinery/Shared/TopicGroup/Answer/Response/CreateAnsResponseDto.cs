namespace Rewinery.Shared.TopicGroup.Answer.Response
{
#pragma warning disable CS8618
    public class CreateAnsResponseDto
    {
        /// <summary>
        /// ID of answer to whom it response belongs
        /// </summary>
        public int AnswerId { get; set; }

        /// <summary>
        /// Usenrame the user who wrote response
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Response text
        /// </summary>
        public string Text { get; set; }
    }
}
