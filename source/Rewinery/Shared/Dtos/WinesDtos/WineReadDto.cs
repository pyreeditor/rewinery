using Rewinery.Shared.Dtos.Base;
using Rewinery.Shared.Dtos.IngredientsDtos;

namespace Rewinery.Shared.Dtos.WinesDtos
{
    public class WineReadDto : BaseDto
    {
#pragma warning disable CS8618
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int GrapeId { get; set; }

        public List<IngredientReadDto> Ingredients { get; set; }


#pragma warning restore CS8618
    }
}
