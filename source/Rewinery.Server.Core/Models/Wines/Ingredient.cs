using Rewinery.Server.Core.Models.Base;

namespace Rewinery.Server.Core.Models.Wines
{
#pragma warning disable CS8618
    public class Ingredient : BaseEntity
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

        public ICollection<Wine>? Wine { get; set; }
    }
}
