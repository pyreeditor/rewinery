using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.CommentGroup.WineCommentsDtos
{
    public class WineCommentCreateDto
    {
        public int WineId { get; set; }

        public string OwnerUserName { get; set; }

        public string CommentText { get; set; }
    }
}
