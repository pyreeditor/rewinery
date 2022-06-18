using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.WineGroup.Comment
{
    #pragma warning disable CS8618
    public class UpdateCommentDto : BaseDto
    {
        /// <summary>
        /// Comment text
        /// </summary>
        public string Text { get; set; }
    }
}
