using Rewinery.Server.Core.Models.Base;

namespace Rewinery.Server.Core.Models.Wines
{
    #pragma warning disable CS8618
    public class Category : BaseEntity
    {
        /// <summary>
        /// Category name
        /// </summary>
        public string Name { get; set; }
    }
}