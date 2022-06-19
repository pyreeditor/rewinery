using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.TopicGroup.TopicPage
{
    #pragma warning disable CS8618
    public class ShortTopicDto : BaseDto
    {
        public string User { get; set; }

        public string Title { get; set; }

        public DateTime Created { get; set; }
    }
}
