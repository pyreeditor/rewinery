using Rewinery.Shared.WineGroup.CategoriesDtos;
using Rewinery.Shared.WineGroup.SubcategoriesDtos;

namespace Rewinery.Shared.WineGroup.GrapesDtos
{
    public class GrapeReadDto : BaseDto
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        public decimal Price { get; set; }

        public CategoryReadDto Category { get; set; }
        public SubcategoryReadDto Subcategory { get; set; }
    }
}
