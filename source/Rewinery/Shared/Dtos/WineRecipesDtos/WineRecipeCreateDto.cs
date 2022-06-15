using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.Dtos.WineRecipesDtos
{
    public class WineRecipeCreateDto
    {
#pragma warning disable CS8618

        public int OwnerId { get; set; }


        public bool Public { get; set; }


        public string Icon { get; set; }


        public int WineId { get; set; }


        public List<int> CommentsIds { get; set; }
#pragma warning restore CS8618
    }
}
