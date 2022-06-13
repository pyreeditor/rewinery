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
        public string Name { get; set; } = "Some ingradient";

        public string Icon { get; set; }

        public decimal Price { get; set; }

        public ICollection<Wine> Wine { get; set; }
    }
}
