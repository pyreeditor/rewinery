using Rewinery.Server.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Server.Core.Models.Comment
{
    public class ReceiptComment : BaseEntity
    {
        public ApplicationUser User { get; set; }

        public string? Comment { get; set; }

        public int Rating { get; set; }

        public ICollection<CommentResponse> Responses { get; set; }
    }
}
