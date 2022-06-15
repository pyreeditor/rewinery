using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rewinery.Server.Core.Models
{
    public class ApplicationUser : IdentityUser
    {        

        /// <summary>
        /// User first name
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// User last name
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// User nickname
        /// </summary>
        public override string UserName { get; set; } = "user" + DatabaseGeneratedOption.Identity;

        /// <summary>
        /// Collection of user-owned wine recipes
        /// </summary>
        public ICollection<WineRecipe>? WineReceipts { get; set; }
    }
}