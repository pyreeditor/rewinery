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
        /// <summary>
        /// Ingredient name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ingredient icon
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Ingredient price
        /// </summary>
        public decimal Price { get; set; }

        public ICollection<Wine>? Wine { get; set; }
        #pragma warning restore CS8618
    }
}
