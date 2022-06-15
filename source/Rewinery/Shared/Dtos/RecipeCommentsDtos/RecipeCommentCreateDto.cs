﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.Dtos.RecipeCommentsDtos
{
    public class RecipeCommentCreateDto
    {
#pragma warning disable CS8618

        public string UserName { get; set; }


        public int RecipeId { get; set; }


        public string? Comment { get; set; }


        public int Rating { get; set; }


        public List<int> ResponsesIds { get; set; }
#pragma warning restore CS8618
    }
}
