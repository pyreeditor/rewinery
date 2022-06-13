using Rewinery.Server.Core.Models.Base;

namespace Rewinery.Server.Core.Models.Wines
{
    public class Category : BaseEntity
    {
        /// <summary>
        /// Category name
        /// </summary>
        public string Name { get; set; } = "Category";
    }
}