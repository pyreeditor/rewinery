using Rewinery.Shared.WineGroup.IngredientsDtos;

namespace Rewinery.Shared.WineGroup.WinesDtos
{
    public class WineUpdateDto : BaseDto
    {
#pragma warning disable CS8618
        public string Name { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public bool Public { get; set; }

#pragma warning restore CS8618
    }
}
