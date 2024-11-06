using Microsoft.EntityFrameworkCore;
using TrainForCooking.Dto;

namespace TrainForCooking.Repository.EF
{
    public class RecipesContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Cuisine> Cuisines { get; set; }

        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

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
            // Configure primary keys
            modelBuilder.Entity<Recipe>().HasKey(r => r.Id);
            modelBuilder.Entity<Ingredient>().HasKey(i => i.Id);
            modelBuilder.Entity<Cuisine>().HasKey(c => c.Id);
           // modelBuilder.Entity<Category>()
            modelBuilder.Entity<RecipeIngredient>().HasKey(ri => ri.Id);


            // Configure RecipeIngredient relationships
            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Ingredent)
                .WithMany()
                .HasForeignKey(ri => ri.IngredientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne<Recipe>()
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(ri => ri.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed Categories
            modelBuilder.Entity<Category>(builder =>
            {
                builder.HasKey(c => c.Id);

                builder.HasData(
                new Category { Id = 1, Name = "Main Course" },
                new Category { Id = 2, Name = "Dessert" },
                new Category { Id = 3, Name = "Appetizer" });
            });

            // Seed Cuisines
            modelBuilder.Entity<Cuisine>().HasData(
                new Cuisine { Id = 1, Name = "Italian" },
                new Cuisine { Id = 2, Name = "Mexican" },
                new Cuisine { Id = 3, Name = "Japanese" }
            );

            // Seed Ingredients
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Tomato" },
                new Ingredient { Id = 2, Name = "Mozzarella Cheese" },
                new Ingredient { Id = 3, Name = "Basil Leaves" },
                new Ingredient { Id = 4, Name = "Ground Beef" },
                new Ingredient { Id = 5, Name = "Tortilla" }
            );

            // Seed Recipes
            modelBuilder.Entity<Recipe>().HasData(
                new Recipe
                {
                    Id = 1,
                    Title = "Margherita Pizza",
                    Author = "Chef Luigi",
                    Instructions = "Spread tomato sauce on dough, add cheese, bake, and top with basil.",
                    CookingTimeInMinutes = 15,
                    PreparationTimeInMinutes = 20,
                    CuisineId = 1,  // Italian
                    CategoryId = 1, // Main Course
                    PriceLevel = PriceLevel.Medium,
                    Difficulty = Difficulty.Medium,
                    ImageUrl = "https://example.com/margherita.jpg"
                },
                new Recipe
                {
                    Id = 2,
                    Title = "Beef Tacos",
                    Author = "Chef Maria",
                    Instructions = "Cook beef, warm tortillas, add toppings.",
                    CookingTimeInMinutes = 10,
                    PreparationTimeInMinutes = 15,
                    CuisineId = 2,  // Mexican
                    CategoryId = 1, // Main Course
                    PriceLevel = PriceLevel.Low,
                    Difficulty = Difficulty.Easy,
                    ImageUrl = "https://example.com/beef_tacos.jpg"
                }
            );

            // Seed RecipeIngredients
            modelBuilder.Entity<RecipeIngredient>().HasData(
                new RecipeIngredient { Id = 1, RecipeId = 1, IngredientId = 1, Quantity = 2 },  // Tomato for Margherita Pizza
                new RecipeIngredient { Id = 2, RecipeId = 1, IngredientId = 2, Quantity = 100, UnitOfMeasure = UnitOfMeasure.Gram },  // Mozzarella for Margherita Pizza
                new RecipeIngredient { Id = 3, RecipeId = 1, IngredientId = 3, Quantity = 5 },     // Basil for Margherita Pizza
                new RecipeIngredient { Id = 4, RecipeId = 2, IngredientId = 4, Quantity = 500, UnitOfMeasure = UnitOfMeasure.Gram },  // Ground Beef for Tacos
                new RecipeIngredient { Id = 5, RecipeId = 2, IngredientId = 5, Quantity = 3 }      // Tortillas for Tacos
            );
        }
    }
}
