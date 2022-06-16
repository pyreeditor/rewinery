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
        #pragma warning disable CS8618
        /// <summary>
        /// Information about user comment for wine recipe
        /// </summary>
        public WineComment Comment { get; set; }

        /// <summary>
        /// Information about the user who written the responce to comment
        /// </summary>
        public ApplicationUser User { get; set; }

        /// <summary>
        /// Text of comment responce
        /// </summary>
        public string Responce { get; set; }
        #pragma warning restore CS8618
    }
}
