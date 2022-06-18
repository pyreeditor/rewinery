using Rewinery.Shared.OrderGroup.OrderStatusDtos;
using Rewinery.Shared.WineGroup.Wine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.OrderGroup.OrdersDtos
{
    public class OrderReadDto : BaseDto
    {
        public UserReadDto User { get; set; }

        public WineDto Wine { get; set; } // створиш сам дтошку, в цый забагато всього, але не знаю толком що викидати.

        public int Volume { get; set; }

        public decimal Price { get; set; }

        public OrderStatusReadDto Status { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
    }
}
