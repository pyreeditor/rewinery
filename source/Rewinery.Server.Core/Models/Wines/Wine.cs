using Rewinery.Server.Core.Models.Base;
using Rewinery.Server.Core.Models.Comment;

namespace Rewinery.Server.Core.Models.Wines
{
    public class Wine : BaseEntity
    {
    #pragma warning disable CS8618
        /// <summary>
        /// Information about the user who owns this recipe
        /// </summary>
        public ApplicationUser Owner { get; set; }

        /// <summary>
        /// Wine name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Information about wine
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Wine icon
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Wine price
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

        /// <summary>
        /// Information about grape used in wine
        /// </summary>
        public Grape Grape { get; set; }

        /// <summary>
        /// Ingredient used in wine
        /// </summary>
        public ICollection<Ingredient> Ingredients { get; set; }

        /// <summary>
        /// Collection of the comment to this recipe
        /// </summary>
        public ICollection<WineComment>? Comments { get; set; }

        /// <summary>
        /// Availability of the wine recipe (This recipe is available to everyone or private)
        /// </summary>
        public bool Public { get; set; }
    #pragma warning restore CS8618
    }
}
