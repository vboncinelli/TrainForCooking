using Microsoft.EntityFrameworkCore;
using TrainForCooking.Dto;

namespace TrainForCooking.Repository.EF
{
    public class RecipesContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Cuisine> Cuisines { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseInMemoryDatabase("RecipesDatabase")
#if DEBUG
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
#endif
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Recipe -> Cuisine (many-to-one)
            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.Cuisine)
                .WithMany()
                .HasForeignKey(r => r.CuisineId)
                .OnDelete(DeleteBehavior.Restrict);

            // Recipe -> Category (many-to-one)
            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.Category)
                .WithMany()
                .HasForeignKey(r => r.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Recipe -> Ingredients (one-to-many)
            modelBuilder.Entity<Recipe>()
                .HasMany(r => r.Ingredients)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
