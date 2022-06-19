using Rewinery.Server.Core.Models.Base;

namespace Rewinery.Server.Core.Models.Topics
{
    #pragma warning disable CS8618
    public class AnswerResponse : BaseEntity
    {
        public Answer Answer { get; set; }

        public ApplicationUser User { get; set; }

        public string Text { get; set; }

        public DateTime Created { get; set; }
    }
}