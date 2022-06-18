using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.WineGroup.WineRecipePage
{
    #pragma warning disable CS8618
    public class ShortWineDto : BaseDto
    {
        public string Owner { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Icon { get; set; }

        public ShortGrapeDto Grape { get; set; }

        public List<ShortIngredientDto> Ingredients { get; set; }
    }
}
