﻿using Rewinery.Shared.Dtos.Base;

namespace Rewinery.Shared.Dtos.GrapesDtos
{
    public class GrapeUpdateDto : BaseDto
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public int SubcategoryId { get; set; }
    }
}
