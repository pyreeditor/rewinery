using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.WineGroup.Ingredient
{
    #pragma warning disable CS8618
    public class UpdateIngredientDto : BaseDto
    {
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
    }
}
