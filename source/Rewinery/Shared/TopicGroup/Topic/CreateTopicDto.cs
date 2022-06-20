namespace Rewinery.Shared.TopicGroup.Topic
{
#pragma warning disable CS8618
    public class CreateTopicDto
    {
        /// <summary>
        /// Username the user who created the topic
        /// </summary>
        public string UserName { get; set; }

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