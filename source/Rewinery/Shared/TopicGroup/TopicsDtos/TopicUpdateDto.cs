using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.TopicGroup.TopicsDtos
{
    public class TopicUpdateDto : BaseDto
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
