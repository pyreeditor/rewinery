using Rewinery.Shared.TopicGroup.Answer.Response;

namespace Rewinery.Shared.TopicGroup.Answer
{
    #pragma warning disable CS8618
    public class AnswerDto : BaseDto
    {
        public string User { get; set; }

        public string Text { get; set; }

        public List<AnsResponseDto>? Responses { get; set; }

        public DateTime Created { get; set; }
    }
}
