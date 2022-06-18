using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.WineGroup.Grape
{
    #pragma warning disable CS8618
    public class UpdateGrapeDto : BaseDto
    {
        /// <summary>
        /// Grape variety name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Grape icon
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Cost of grape for production one liter of wine
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Category name (red, white, pink)
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Subcategory name (dry, sweet, semi-sweet...)
        /// </summary>
        public int SubcategoryId { get; set; }
    }
}
