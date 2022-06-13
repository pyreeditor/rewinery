using Rewinery.Server.Core.Models.Base;

namespace Rewinery.Server.Core.Models.Wines
{
    public class Wine : BaseEntity
    {
        public string Name { get; set; } = "Wine";

        public string Description { get; set; } = "Some text";

        public decimal Price { get; set; }

        public Grape Grape { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
