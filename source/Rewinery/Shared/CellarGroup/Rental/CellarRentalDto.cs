using Rewinery.Shared.WineGroup.WineRecipePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.CellarGroup.Rental
{
    #pragma warning disable CS8618
    public class CellarRentalDto : BaseDto
    {
        public string CellarName { get; set; }

        /// <summary>
        /// Wine owner
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Number of wine bottle
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Information about wine which is stored
        /// </summary>
        public ShortWineDto Wine { get; set; }

        /// <summary>
        /// Rental start date
        /// </summary>
        public DateTime StartRental { get; set; }

        /// <summary>
        /// Rental end date
        /// </summary>
        public DateTime EndRental { get; set; }
    }
}
