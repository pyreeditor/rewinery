using Rewinery.Shared.Dtos.Base;
using Rewinery.Shared.Dtos.CategoriesDtos;
using Rewinery.Shared.Dtos.SubcategoriesDtos;

namespace Rewinery.Shared.Dtos.GrapesDtos
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
