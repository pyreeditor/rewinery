using Rewinery.Shared.TopicGroup.Answer;

namespace Rewinery.Shared.TopicGroup.Topic
{
#pragma warning disable CS8618
    public class TopicDto : BaseDto
    {
        /// <summary>
        /// Username the user who created the topic
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Topic title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The question or hypothesis the user wants to discuss
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// List of answers to topic
        /// </summary>
        public List<AnswerDto>? Answers { get; set; }

        /// <summary>
        /// Topic created time
        /// </summary>
        public DateTime Created { get; set; }

    }
}
