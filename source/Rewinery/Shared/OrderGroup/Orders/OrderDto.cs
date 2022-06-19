using Rewinery.Shared.OrderGroup.OrderStatus;
using Rewinery.Shared.WineGroup.WineRecipePage;

namespace Rewinery.Shared.OrderGroup.Orders
{
    #pragma warning disable CS8618
    public class OrderDto : BaseDto
    {
        public string User { get; set; }

        public ShortWineDto Wine { get; set; }

        public int Volume { get; set; }

        public decimal Price { get; set; }

        public OrderStatusDto Status { get; set; }

        public DateTime Created { get; set; }
    }
}
