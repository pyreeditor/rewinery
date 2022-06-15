using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.Dtos.CommentResponsesDtos
{
    public class CommentResponseCreateDto
    {
        public int CommentId { get; set; }

        public int UserId { get; set; }

        public string Responce { get; set; }
    }
}
