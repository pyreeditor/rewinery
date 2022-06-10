using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Rewinery.Server.Core.Models;
using Rewinery.Server.Core.Models.Comment;
using Rewinery.Server.Core.Models.Wines;

namespace Rewinery.Server.Core
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<WineReceipt> WineReceipts { get; set; }

        #region wine
        public DbSet<Wine> Wines { get; set; }

        public DbSet<Grape> Grapes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Subcategory> Subcategories { get; set; }
        #endregion

        #region comment
        public DbSet<ReceiptComment> ReceiptComments { get; set; }

        public DbSet<CommentResponse> CommentResponses { get; set; }
        #endregion
    }
}