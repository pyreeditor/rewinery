using Rewinery.Server.Core.Models.Base;

namespace Rewinery.Server.Core.Models.Cellars
{
    #pragma warning disable CS8618
    public class Cellar : BaseEntity
    {
        /// <summary>
        /// Cellar name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  Cellar capacity
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Cellar rental collection
        /// </summary>
        public ICollection<CellarRental>? CellarRental { get; set; }
    }
}
