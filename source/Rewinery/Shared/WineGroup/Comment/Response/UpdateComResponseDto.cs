using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.WineGroup.Comment.Response
{
    #pragma warning disable CS8618
    public class UpdateComResponseDto : BaseDto
    {
        public string Text { get; set; }
    }
}
