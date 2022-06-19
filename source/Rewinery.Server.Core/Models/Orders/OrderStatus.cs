using Rewinery.Server.Core.Models.Base;

namespace Rewinery.Server.Core.Models.Orders
{
    #pragma warning disable CS8618
    public class OrderStatus : BaseEntity
    {
        public string Status { get; set; }
    }
}