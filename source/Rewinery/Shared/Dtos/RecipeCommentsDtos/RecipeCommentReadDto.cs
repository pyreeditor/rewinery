using Rewinery.Shared.Dtos.Base;

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
