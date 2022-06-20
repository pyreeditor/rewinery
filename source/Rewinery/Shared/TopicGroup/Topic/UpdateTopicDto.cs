namespace Rewinery.Shared.TopicGroup.Topic
{
#pragma warning disable CS8618
    public class UpdateTopicDto : BaseDto
    {
        /// <summary>
        /// Topic title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The question or hypothesis the user wants to discuss
        /// </summary>
        public string Description { get; set; }
    }
}
