using Microsoft.EntityFrameworkCore;
using TestWebApplication.Models;

namespace TestWebApplication.ContextDB
{
    public class ContextDb : DbContext
    {
        public DbSet<Img> Imgs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public ContextDb(DbContextOptions<ContextDb> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Comment>().HasKey(u => u.CommentsId);
            modelBuilder.Entity<Img>().HasKey(u => u.ImgsId);


        }
    }
}
