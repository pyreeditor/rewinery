using Rewinery.Server.Core.Models.Base;

namespace Rewinery.Server.Core.Models.Cellar
{
    public class Cellar : BaseEntity
    {
        #pragma warning disable CS8618
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
        public ICollection<CellarRental> CellarRental { get; set; }
        #pragma warning restore CS8618
    }
}
