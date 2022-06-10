using Rewinery.Server.Core.Models.Base;

namespace Rewinery.Server.Core.Models.Wines
{
    public class Grape : BaseEntity
    {
        public string Name { get; set; } = "Grape";

        public decimal Price { get; set; }

        public Category Category { get; set; } = new Category();

        public Subcategory Subcategory { get; set; } = new Subcategory();
    }
}