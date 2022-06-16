using Rewinery.Server.Core.Models.Base;

namespace Rewinery.Server.Core.Models.Wines
{
    public class Wine : BaseEntity
    {
        #pragma warning disable CS8618
        /// <summary>
        /// Wine name
        /// </summary>
        public string Name { get; set; } = "Wine";

        /// <summary>
        /// Information about wine
        /// </summary>
        public string Description { get; set; } = "Some text";

        /// <summary>
        /// Wine price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Information about grape used in wine
        /// </summary>
        public Grape Grape { get; set; }

        /// <summary>
        /// Ingredient used in wine
        /// </summary>
        public List<Ingredient> Ingredients { get; set; }
        #pragma warning restore CS8618
    }
}
