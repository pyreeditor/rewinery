using Rewinery.Shared.TopicGroup.AnswerResponsesDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.TopicGroup.AnswersDtos
{
    public class AnswerReadDto : BaseDto
    {
        public string OwnerUserName { get; set; }

        public string AnswerText { get; set; }

        public List<AnswerResponseReadDto>? AnswerResponsesList { get; set; }

        public DateTime Created { get; set; }
    }
}
