using Rewinery.Server.Core.Models.Base;
using Rewinery.Server.Core.Models.Wines;

namespace Rewinery.Server.Core.Models.Cellar
{
    public class CellarRental : BaseEntity
    {
        #pragma warning disable CS8618
        /// <summary>
        /// Wine owner
        /// </summary>
        public ApplicationUser Owner { get; set; }

        /// <summary>
        /// Number of wine bottle
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Information about wine which is stored
        /// </summary>
        public Wine Wine { get; set; }

        /// <summary>
        /// Rental start date
        /// </summary>
        public DateTime StartRental { get; set; }

        /// <summary>
        /// Rental end date
        /// </summary>
        public DateTime EndRental { get; set; }
        #pragma warning restore CS8618
    }
}
