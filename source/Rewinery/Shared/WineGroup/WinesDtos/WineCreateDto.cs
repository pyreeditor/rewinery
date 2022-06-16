using Rewinery.Shared.WineGroup.IngredientsDtos;

namespace Rewinery.Shared.WineGroup.WinesDtos
{
    public class WineCreateDto
    {
#pragma warning disable CS8618
        public string Name { get; set; }

        public string Description { get; set; }


        public int GrapeId { get; set; }

        public List<int> IngredientsIds { get; set; }

#pragma warning restore CS8618
    }
}
