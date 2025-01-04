using Microsoft.EntityFrameworkCore;
using TestSample.Models;

namespace TestSample.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding Tags table
            modelBuilder.Entity<Tag>().HasData(
                new Tag { Id = 1, Name = "Technology" },
                new Tag { Id = 2, Name = "Science" },
                new Tag { Id = 3, Name = "Health" },
                new Tag { Id = 4, Name = "Lifestyle" }
            );

            // Seeding BlogPosts table
            modelBuilder.Entity<BlogPost>().HasData(
                new BlogPost
                {
                    Id = 1,
                    Title = "The Future of Technology",
                    Content = "This post discusses the future trends in technology.",
                    CreatedTime = DateTime.Now,
                },
                new BlogPost
                {
                    Id = 2,
                    Title = "The Wonders of Science",
                    Content = "This post explores the wonders of scientific discoveries.",
                    CreatedTime = DateTime.Now
                },
                new BlogPost
                {
                    Id = 3,
                    Title = "How earth got shaped",
                    Content = "This post explores how earth was shaped.",
                    CreatedTime = DateTime.Now
                },
                new BlogPost
                {
                    Id = 4,
                    Title = "The Point of living",
                    Content = "This post explores the points of living.",
                    CreatedTime = DateTime.Now
                }
            );
            
        }
    }
}
