using Rewinery.Server.Core.Models.Base;
using Rewinery.Server.Core.Models.Comment;
using Rewinery.Server.Core.Models.Wines;

namespace Rewinery.Server.Core.Models
{
    public class WineReceipt : BaseEntity
    {
        public ApplicationUser Owner { get; set; }

        public bool Public { get; set; }

        public string Icon { get; set; }

        public Wine Wine { get; set; }

        public ICollection<ReceiptComment> Comments { get; set; }
    }
}
