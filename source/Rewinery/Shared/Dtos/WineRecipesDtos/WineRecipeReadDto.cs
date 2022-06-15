using Rewinery.Shared.Dtos.Base;
using Rewinery.Shared.Dtos.IngredientsDtos;
using Rewinery.Shared.Dtos.RecipeCommentsDtos;
using Rewinery.Shared.Dtos.UsersDtos;
using Rewinery.Shared.Dtos.WinesDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.Dtos.WineRecipesDtos
{
    public class WineRecipeReadDto : BaseDto
    {
#pragma warning disable CS8618
        
        public UserReadDto ApplicationUser { get; set; }
 
        public bool Public { get; set; }

        public string Icon { get; set; }

        public WineReadDto Wine { get; set; }

        public List<RecipeCommentReadDto> Comments { get; set; }

#pragma warning restore CS8618
    }
}
