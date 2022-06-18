using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Shared.OrderGroup.OrdersDtos
{
    public class OrderCreateDto
    {
        public string OwnerUserName { get; set; }

        public int WineId { get; set; }

        public int Volume { get; set; }

        public decimal Price { get; set; }

        public int StatusId { get; set; }

        public DateTime Created { get; set; }
    }
}
