namespace Rewinery.Shared.WineGroup.WineRecipePage
{
#pragma warning disable CS8618
    public class ShortWineDto : BaseDto
    {
        /// <summary>
        /// UserName the owner of the wine
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Wine name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Price per liter of wine
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Wine icon
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Brief information about the grapes used to make wine
        /// </summary>
        public ShortGrapeDto Grape { get; set; }

        /// <summary>
        /// A list of brief information about the ingredients that are part of the wine
        /// </summary>
        public List<ShortIngredientDto> Ingredients { get; set; }
    }
}
