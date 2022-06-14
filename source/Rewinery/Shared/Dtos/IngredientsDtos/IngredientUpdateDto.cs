using Rewinery.Shared.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.Dtos.IngredientsDtos
{
    public class IngredientUpdateDto : BaseDto
    {
        #pragma warning disable CS8618
        public string Name { get; set; }

        public string Icon { get; set; }

        public decimal Price { get; set; }

        #pragma warning restore CS8618

    }
}
