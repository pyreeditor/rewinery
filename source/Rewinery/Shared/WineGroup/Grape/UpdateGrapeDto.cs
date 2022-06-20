namespace Rewinery.Shared.WineGroup.Grape
{
#pragma warning disable CS8618
    public class UpdateGrapeDto : BaseDto
    {
        /// <summary>
        /// Grape sort name
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
        /// Grape category ID
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Grape subcategory ID
        /// </summary>
        public int SubcategoryId { get; set; }
    }
}
