using Rewinery.Server.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Server.Core.Models.Comment
{
    public class CommentResponse : BaseEntity
    {
        public ReceiptComment Comment { get; set; }

        public ApplicationUser User { get; set; }

        public string Responce { get; set; }
    }
}
