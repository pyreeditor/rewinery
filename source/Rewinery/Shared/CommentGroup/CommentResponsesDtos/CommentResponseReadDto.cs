using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.CommentGroup.CommentResponsesDtos
{
    public class CommentResponseReadDto : BaseDto
    {
        public string OwnerUserName { get; set; }

        public string Response { get; set; }

        public DateTime Created { get; set; }
    }
}
