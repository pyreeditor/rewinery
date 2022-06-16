using Rewinery.Server.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Server.Core.Models.Wines
{
    public class IngredientWine
    {
        public Wine Wine { get; set; }

        public Ingredient Ingredient { get; set; }
    }
}
