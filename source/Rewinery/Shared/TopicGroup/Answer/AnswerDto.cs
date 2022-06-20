using Rewinery.Shared.TopicGroup.Answer.Response;

namespace Rewinery.Shared.TopicGroup.Answer
{
    #pragma warning disable CS8618
    public class AnswerDto : BaseDto
    {
        /// <summary>
        /// Username the user who wrote answer
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Answer text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// List of response to answer
        /// </summary>
        public List<AnsResponseDto>? Responses { get; set; }

        /// <summary>
        /// Answer created time
        /// </summary>
        public DateTime Created { get; set; }
    }
}
