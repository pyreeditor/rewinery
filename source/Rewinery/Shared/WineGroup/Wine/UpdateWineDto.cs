using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.WineGroup.Wine
{
    #pragma warning disable CS8618
    public class UpdateWineDto : BaseDto
    {
        /// <summary>
        /// Wine recipe name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the wine making process
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Wine icon
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Availability of the recipe for other users
        /// <br/> True -> Public <br/> False -> Private
        /// </summary>
        public bool Public { get; set; }
    }
}
