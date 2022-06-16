using Rewinery.Server.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Server.Core.Models.Wines
{
    public class Ingredient : BaseEntity
    {
        #pragma warning disable CS8618
        public string Name { get; set; }

        public string Icon { get; set; }

        public decimal Price { get; set; }

        public ICollection<Wine> Wine { get; set; }
        #pragma warning restore CS8618
    }
}
