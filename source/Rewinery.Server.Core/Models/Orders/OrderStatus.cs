using Rewinery.Server.Core.Models.Base;

namespace Rewinery.Server.Core.Models.Orders
{
    public class OrderStatus : BaseEntity
    {
        #pragma warning disable CS8618

        public string Status { get; set; }
        #pragma warning restore CS8618
    }
}