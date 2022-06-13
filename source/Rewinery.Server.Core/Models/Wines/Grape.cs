using Rewinery.Server.Core.Models.Base;

namespace Rewinery.Server.Core.Models.Wines
{
    public class Grape : BaseEntity
    {
        public string Name { get; set; } = "Grape";

        public string Icon { get; set; }

        public decimal Price { get; set; }

        public Category Category { get; set; }

        public Subcategory Subcategory { get; set; }
    }
}