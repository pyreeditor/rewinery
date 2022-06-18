using Rewinery.Server.Core.Models.Base;

namespace Rewinery.Server.Core.Models.Topics
{
    public class AnswerResponse : BaseEntity
    {
        public Answer Answer { get; set; }

        public ApplicationUser User { get; set; }

        public string ResponseText { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
    }
}