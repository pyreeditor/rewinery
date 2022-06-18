using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.WineGroup.Wine
{
    #pragma warning disable CS8618
    public class CreateWineDto
    {
        /// <summary>
        /// Wine recipe owner user name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Wine recipe name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the wine making process
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Price per liter of wine
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Wine icon
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Wine grape ID 
        /// </summary>
        public int GrapeId { get; set; }

        /// <summary>
        /// List of ingredients that are part of the wine
        /// </summary>
        public List<int> Inredients { get; set; }

        /// <summary>
        /// Availability of the recipe for other users
        /// <br/> True -> Public <br/> False -> Private
        /// </summary>
        public bool Public { get; set; }
    }
}
