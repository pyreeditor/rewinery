using Rewinery.Shared.TopicGroup.Answer;

namespace Rewinery.Shared.TopicGroup.Topic
{
#pragma warning disable CS8618
    public class TopicDto : BaseDto
    {
        public string User { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<AnswerDto>? Answers { get; set; }

        public DateTime Created { get; set; }

    }
}
