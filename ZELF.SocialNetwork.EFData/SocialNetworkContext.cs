using Microsoft.EntityFrameworkCore;
using ZELF.SocialNetwork.EFData.Models;

namespace ZELF.SocialNetwork.EFData
{
    public class SocialNetworkContext : DbContext
    {
        public SocialNetworkContext(DbContextOptions<SocialNetworkContext> options) : base(options)
        {

        }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<SubscribeUserEntity> UserSubscribers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<SubscribeUserEntity>(builder => { builder.HasKey(x => new {x.FromUserId, x.ToUserId}); });
        }
    }
}
