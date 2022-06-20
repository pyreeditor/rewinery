namespace Rewinery.Shared.OrderGroup.Orders
{
    #pragma warning disable CS8618
    public class CreateOrderDto
    {
        /// <summary>
        /// Username the user who made the order
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// ID wine that was ordered
        /// </summary>
        public int WineId { get; set; }

        /// <summary>
        /// Volume of wine
        /// </summary>
        public int Volume { get; set; }

        /// <summary>
        /// Order cost
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Order status ID
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Order created time
        /// </summary>
        public DateTime Created { get; set; }
    }
}
