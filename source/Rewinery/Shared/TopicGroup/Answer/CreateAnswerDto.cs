using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.TopicGroup.Answer
{
    #pragma warning disable CS8618
    public class CreateAnswerDto
    {
        public int TopicId { get; set; }

        public string UserName { get; set; }

        public string Text { get; set; }
    }
}
