using Rewinery.Server.Core.Models.Base;

namespace Rewinery.Server.Core.Models.Wines
{
    public class Grape : BaseEntity
    {
        #pragma warning disable CS8618
        /// <summary>
        /// Grape variety name
        /// </summary>
        public string Name { get; set; } = "Grape";

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
        public Category Category { get; set; }

        /// <summary>
        /// Subcategory name (dry, sweet, semi-sweet...)
        /// </summary>
        public Subcategory Subcategory { get; set; }
        #pragma warning restore CS8618
    }
}