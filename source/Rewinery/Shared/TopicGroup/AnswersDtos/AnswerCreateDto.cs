using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.TopicGroup.AnswersDtos
{
    public class AnswerCreateDto
    {
        public int TopicId { get; set; }

        public string OwnerUserName { get; set; }

        public string AnswerText { get; set; }

    }
}
