using Rewinery.Server.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Server.Core.Models.Orders
{
    public class Order : BaseEntity
    {
        public ApplicationUser User { get; set; }

        public WineReceipt Wine { get; set; }

        public int Volume { get; set; }

        public decimal Price { get; set; }

        public OrderStatus Status { get; set; }
    }
}
