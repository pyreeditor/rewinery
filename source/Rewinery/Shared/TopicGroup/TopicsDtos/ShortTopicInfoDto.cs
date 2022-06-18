using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.TopicGroup.TopicsDtos
{
    public class ShortTopicInfoDto : BaseDto
    {
        public string OwnerUserName { get; set; }

        public string Title { get; set; }

        public DateTime Created { get; set; }
    }
}
