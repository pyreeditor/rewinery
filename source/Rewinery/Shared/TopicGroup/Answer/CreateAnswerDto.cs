namespace Rewinery.Shared.TopicGroup.Answer
{
#pragma warning disable CS8618
    public class CreateAnswerDto
    {
        /// <summary>
        /// ID of topic to which the answer belongs
        /// </summary>
        public int TopicId { get; set; }

        /// <summary>
        /// Username the user who wrote answer
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Answer text
        /// </summary>
        public string Text { get; set; }
    }
}
