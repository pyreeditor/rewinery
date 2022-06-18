using Rewinery.Shared.TopicGroup.AnswersDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.TopicGroup.TopicsDtos
{
    public class TopicPageDto : BaseDto
    {
        public string OwnerUserName { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public List<AnswerReadDto>? Answers { get; set; }

    }
}
