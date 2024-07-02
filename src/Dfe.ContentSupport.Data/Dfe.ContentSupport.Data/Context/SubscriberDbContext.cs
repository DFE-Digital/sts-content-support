using Dfe.ContentSupport.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Dfe.ContentSupport.Data.Context
{
    public class SubscriberDbContext : DbContext
    {
        public SubscriberDbContext(DbContextOptions<SubscriberDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Subscriber>(entity => { entity.ToTable(name: "Subscribers"); });

            base.OnModelCreating(builder);
        }

        public DbSet<Subscriber> Subscribers { get; set;}
    }
}
