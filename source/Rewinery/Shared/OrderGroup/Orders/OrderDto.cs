using Rewinery.Shared.OrderGroup.OrderStatus;
using Rewinery.Shared.WineGroup.WineRecipePage;

namespace Rewinery.Shared.OrderGroup.Orders
{
#pragma warning disable CS8618
    public class OrderDto : BaseDto
    {
        /// <summary>
        /// Username the user who made the order
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Information about the wine that was ordered
        /// </summary>
        public ShortWineDto Wine { get; set; }

        /// <summary>
        /// Volume of wine
        /// </summary>
        public int Volume { get; set; }

        /// <summary>
        /// Order cost
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Order status
        /// </summary>
        public OrderStatusDto Status { get; set; }

        /// <summary>
        /// Order created time
        /// </summary>
        public DateTime Created { get; set; }
    }
}
