using Rewinery.Shared.CellarGroup.Rental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.CellarGroup.Cellar
{
    #pragma warning disable CS8618
    public class CellarDto : BaseDto
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
        public List<CellarRentalDto>? Rental { get; set; }
    }
}
