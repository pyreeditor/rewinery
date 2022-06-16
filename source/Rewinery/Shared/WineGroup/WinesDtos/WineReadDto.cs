using AutoMapper;
using Rewinery.Shared.WineGroup.IngredientsDtos;

namespace Rewinery.Shared.WineGroup.WinesDtos
{
    public class WineReadDto : BaseDto
    {
#pragma warning disable CS8618
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string GrapeName { get; set; }
        public string CategoryName { get; set; }
        public string SubcategoryName { get; set; }

        public List<IngredientReadDto> Ingredients { get; set; }


#pragma warning restore CS8618
    }
}
