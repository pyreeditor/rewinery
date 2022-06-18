using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.WineGroup.Comment.Response
{
    #pragma warning disable CS8618
    public class CreateComResponseDto
    {
        public int CommentId { get; set; }
        public string User { get; set; }
        public string Text { get; set; }
    }
}
