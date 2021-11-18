using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PieGallery.Models;

namespace PieGallery.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Published>().HasKey(x => new { x.AuthorId, x.PublisherId });
        }

        public DbSet<PieGallery.Models.Comics> Comics { get; set; }
        //public DbSet<Comics> Comic { get; set; }
        //public DbSet<Authors> Author { get; set; }
        //public DbSet<Publisher> Publisher { get; set; }
        //public DbSet<Published> Published { get; set; }
    }
}
