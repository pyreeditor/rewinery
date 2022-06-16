using Rewinery.Server.Core.Models.Base;

namespace Rewinery.Server.Core.Models.Topics
{
    public class Answer : BaseEntity
    {
        public Topic Topic { get; set; }
        public ApplicationUser User { get; set; }

        public string AnswerText { get; set; }

        public ICollection<AnswerResponce> AnswerResponces { get; set; }
    }
}