using ActionApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ActionApi.DB
{
    public class Connect : DbContext
    {
        public Connect(DbContextOptions options) : base(options)
        {
        }
        public DbSet<MainCategory>mainCategories { get; set; }
        public DbSet<Producer> producers { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<SubCategory> subCategories { get; set; }

    }
}
