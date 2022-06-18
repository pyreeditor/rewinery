using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.TopicGroup.TopicsDtos
{
    public class TopicCreateDto
    {
        public string OwnerUserName { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}