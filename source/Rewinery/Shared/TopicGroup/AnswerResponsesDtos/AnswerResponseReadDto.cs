using Rewinery.Shared.TopicGroup.AnswersDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.TopicGroup.AnswerResponsesDtos
{
    public class AnswerResponseReadDto : BaseDto
    {
        public string OwnerUserName { get; set; }

        public string ResponseText { get; set; }

        public DateTime Created { get; set; }
    }
}
