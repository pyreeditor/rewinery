using Rewinery.Shared.Dtos.Base;
using Rewinery.Shared.Dtos.RecipeCommentsDtos;
using Rewinery.Shared.Dtos.UsersDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.Dtos.CommentResponsesDtos
{
    public class CommentResponseReadDto : BaseDto
    {
#pragma warning disable CS8618

        public RecipeCommentReadDto Comment { get; set; }

        public UserReadDto User { get; set; }

  
        public string Responce { get; set; }
#pragma warning restore CS8618
    }
}
