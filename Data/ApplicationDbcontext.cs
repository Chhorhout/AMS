    using AMS.Api.Models;
using Microsoft.EntityFrameworkCore;
using AMS.Api.Data.Configs;
namespace AMS.Api.Data
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {
        }
        public DbSet<Assets> Assets { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply configurations from the assembly in folder Configs
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssetConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoriesConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LocationConfiguration).Assembly);
        }
    }
}