using Rewinery.Server.Core.Models.Base;

namespace Rewinery.Server.Core.Models.Wines
{
    #pragma warning disable CS8618
    public class Subcategory : BaseEntity
    {
        /// <summary>
        /// Subcategory name
        /// </summary>
        public string Name { get; set; }
    }
}