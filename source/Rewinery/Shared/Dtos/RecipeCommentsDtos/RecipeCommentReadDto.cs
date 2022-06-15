using Rewinery.Shared.Dtos.Base;
using Rewinery.Shared.Dtos.CommentResponsesDtos;
using Rewinery.Shared.Dtos.UsersDtos;
using Rewinery.Shared.Dtos.WineRecipesDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.Dtos.RecipeCommentsDtos
{
    public class RecipeCommentReadDto : BaseDto
    {
#pragma warning disable CS8618
        
       // public UserReadDto User { get; set; }

        public string? Comment { get; set; }

       
        public int Rating { get; set; }

        
        //public List<CommentResponseReadDto>? Responses { get; set; }
#pragma warning restore CS8618
    }
}
