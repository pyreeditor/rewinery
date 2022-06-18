using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.TopicGroup.AnswerResponsesDtos
{
    public class AnswerResponseCreateDto
    {
        public int AnswerId { get; set; }

        public string OwnerUserName { get; set; }

        public string ResponseText { get; set; }
    }
}
