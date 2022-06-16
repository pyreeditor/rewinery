using Rewinery.Server.Core.Models.Base;

namespace Rewinery.Server.Core.Models.Topics
{
    public class AnswerResponce : BaseEntity
    {
        public Answer Answer { get; set; }

        public ApplicationUser User { get; set; }

        public string ResponceText { get; set; }
    }
}