namespace Rewinery.Shared.OrderGroup.Orders
{
    #pragma warning disable CS8618
    public class CreateOrderDto
    {
        public string UserName { get; set; }

        public int WineId { get; set; }

        public int Volume { get; set; }

        public decimal Price { get; set; }

        public int StatusId { get; set; }

        public DateTime Created { get; set; }
    }
}
