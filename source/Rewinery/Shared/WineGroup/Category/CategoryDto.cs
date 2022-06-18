using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.WineGroup.Category
{
    #pragma warning disable CS8618
    public class CategoryDto : BaseDto
    {
        /// <summary>
        /// Category name
        /// </summary>
        public string Name { get; set; }
    }
}
