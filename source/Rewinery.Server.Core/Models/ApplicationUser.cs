using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rewinery.Server.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public override string UserName { get; set; } = "user" + DatabaseGeneratedOption.Identity;

        public ICollection<WineReceipt>? WineReceipts { get; set; }
    }
}