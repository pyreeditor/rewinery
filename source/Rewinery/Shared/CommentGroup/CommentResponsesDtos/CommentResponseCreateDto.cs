using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.CommentGroup.CommentResponsesDtos
{
    public class CommentResponseCreateDto
    {
        public int CommentId { get; set; }

        public string OwnerUserName { get; set; }

        public string Response { get; set; }
    }
}
