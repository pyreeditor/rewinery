using Rewinery.Shared.CommentGroup.CommentResponsesDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
          
namespace Rewinery.Shared.CommentGroup.WineCommentsDtos
{
    public class WineCommentReadDto : BaseDto
    {
        public string CommentOwnerUserName { get; set; }

        public string Comment { get; set; }

        public DateTime Created { get; set; }

        public List<CommentResponseReadDto>? CommentResponsesList { get; set; }
    }
}
