using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.WineGroup.Comment
{
    #pragma warning disable CS8618
    public class CreateCommentDto
    {
        /// <summary>
        /// Comment owner user name
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// ID of the wine to which this comment belongs
        /// </summary>
        public int WineId { get; set; }

        /// <summary>
        /// Comment text
        /// </summary>
        public string Text { get; set; }
    }
}
