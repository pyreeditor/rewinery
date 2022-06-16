using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Rewinery.Server.Core.Models;
using Rewinery.Server.Core.Models.Cellar;
using Rewinery.Server.Core.Models.Comment;
using Rewinery.Server.Core.Models.Orders;
using Rewinery.Server.Core.Models.Topics;
using Rewinery.Server.Core.Models.Wines;

namespace Rewinery.Server.Core
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        #pragma warning disable CS8618
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        #pragma warning restore CS8618

        #region wine
        public DbSet<Wine> Wines { get; set; }

        public DbSet<Grape> Grapes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Subcategory> Subcategories { get; set; }
        #endregion

        #region comment
        public DbSet<WineComment> WineComments { get; set; }

        public DbSet<CommentResponse> CommentResponses { get; set; }
        #endregion

        #region order
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderStatus> OrderStatuses { get; set; }
        #endregion

        #region cellar
        public DbSet<Cellar> Cellars { get; set; }

        public DbSet<CellarRental> CellarRentals { get; set; }
        #endregion

        #region topic
        public DbSet<Topic> Topics { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<AnswerResponse> AnswerResponces { get; set; }
        #endregion
    }
}