using MarkupApi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MarkupApi.Infrastructure
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<MarkupDetail> MarkupDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MarkupDetail>().Property(b => b.CreatedOn)
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()")
                        .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);

            modelBuilder.Entity<MarkupDetail>().Property(b => b.UpdatedOn)
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("getdate()")
                        .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
        }
    }
}
