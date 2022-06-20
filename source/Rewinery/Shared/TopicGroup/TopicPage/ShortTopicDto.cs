namespace Rewinery.Shared.TopicGroup.TopicPage
{
#pragma warning disable CS8618
    public class ShortTopicDto : BaseDto
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
        /// Topic created time
        /// </summary>
        public DateTime Created { get; set; }
    }
}
