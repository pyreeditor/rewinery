using Rewinery.Server.Core.Models.Base;

namespace Rewinery.Server.Core.Models.Topics
{
#pragma warning disable CS8618
    public class Answer : BaseEntity
    {
        public Topic Topic { get; set; }
        public ApplicationUser User { get; set; }

        public string AnswerText { get; set; }

        public ICollection<AnswerResponse>? AnswerResponces { get; set; }

        public DateTime? Created { get; set; } = DateTime.Now;
    }
}