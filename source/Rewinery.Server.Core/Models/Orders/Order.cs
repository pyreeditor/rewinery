using Rewinery.Server.Core.Models.Base;
using Rewinery.Server.Core.Models.Wines;

namespace Rewinery.Server.Core.Models.Orders
{
    #pragma warning disable CS8618
    public class Order : BaseEntity
    {
        public ApplicationUser User { get; set; }

        public Wine Wine { get; set; }

        public int Volume { get; set; }

        public decimal Price { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime Created { get; set; }
    }
}
