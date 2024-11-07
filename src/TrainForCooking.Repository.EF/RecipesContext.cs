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
                new Category { Id = 1, Name = "Primo" },
                new Category { Id = 2, Name = "Secondo" },
                new Category { Id = 3, Name = "Dessert" });
            });

            // Seed Cuisines
            modelBuilder.Entity<Cuisine>().HasData(
                new Cuisine { Id = 1, Name = "Italiana" },
                new Cuisine { Id = 2, Name = "Messicana" },
                new Cuisine { Id = 3, Name = "Giapponese" },
                new Cuisine { Id = 4, Name = "Cinese" }
            );

            // Seed Ingredients
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Pomodori" },
                new Ingredient { Id = 2, Name = "Mozzarella" },
                new Ingredient { Id = 3, Name = "Basilico" },

                new Ingredient { Id = 4, Name = "Carne macinata" },
                new Ingredient { Id = 5, Name = "Tortilla" },

                new Ingredient { Id = 6, Name = "Riso" },
                new Ingredient { Id = 7, Name = "Piselli" },
                new Ingredient { Id = 8, Name = "Funghi" },

                new Ingredient { Id = 9, Name = "Mascarpone" },
                new Ingredient { Id = 10, Name = "Biscotti savoiardi" },
                new Ingredient { Id = 11, Name = "Cacao in polvere" }
            );

            // Seed Recipes
            modelBuilder.Entity<Recipe>().HasData(
                new Recipe
                {
                    Id = 1,
                    Title = "Pizza margherita",
                    Author = "Chef Luigi",
                    Instructions = "Impasta la pizza, aggiungi pomodoro e mozzarella, informa a 200 gradi e quando è pronta aggiungi il basilico",
                    CookingTimeInMinutes = 15,
                    PreparationTimeInMinutes = 20,
                    CuisineId = 1,  // Italian
                    CategoryId = 1, // Secondo
                    PriceLevel = PriceLevel.Medium,
                    Difficulty = Difficulty.Medium,
                    ImageUrl = "images/margherita.jpg"
                },
                new Recipe
                {
                    Id = 2,
                    Title = "Tacos di carne",
                    Author = "Chef Maria",
                    Instructions = "Cucina il macinato di carne, riscalda la tortilla e aggiungi la carne",
                    CookingTimeInMinutes = 10,
                    PreparationTimeInMinutes = 15,
                    CuisineId = 2,  // Mexican
                    CategoryId = 1, // Main Course
                    PriceLevel = PriceLevel.Low,
                    Difficulty = Difficulty.Medium,
                    ImageUrl = "images/tacos.jpg"
                },
                new Recipe
                {
                    Id = 3,
                    Title = "Riso cantonese",
                    Author = "Chef Maria",
                    Instructions = "Cuoci il riso, aggiungi piselli e funghi",
                    CookingTimeInMinutes = 20,
                    PreparationTimeInMinutes = 20,
                    CuisineId = 4,  
                    CategoryId = 1,
                    PriceLevel = PriceLevel.Low,
                    Difficulty = Difficulty.Easy,
                    ImageUrl = "images/cantonese.jpg"
                },
                new Recipe
                {
                    Id = 4,
                    Title = "Tiramisù",
                    Author = "Chef Vanni",
                    Instructions = "Stendi i biscotti, ricopri di mascarpone e versaci sopra il cacao in polvere",
                    PreparationTimeInMinutes = 25,
                    CuisineId = 1,  
                    CategoryId = 3,
                    PriceLevel = PriceLevel.Low,
                    Difficulty = Difficulty.Easy,
                    ImageUrl = "images/cantonese.jpg"
                }
            );

            // Seed RecipeIngredients
            modelBuilder.Entity<RecipeIngredient>().HasData(
                // Pizza margherita
                new RecipeIngredient { Id = 1, RecipeId = 1, IngredientId = 1, Quantity = 2 },  // Tomato for Margherita Pizza
                new RecipeIngredient { Id = 2, RecipeId = 1, IngredientId = 2, Quantity = 100, UnitOfMeasure = UnitOfMeasure.Gram },  // Mozzarella for Margherita Pizza
                new RecipeIngredient { Id = 3, RecipeId = 1, IngredientId = 3, Quantity = 5 },     // Basil for Margherita Pizza
                
                // Tacos
                new RecipeIngredient { Id = 4, RecipeId = 2, IngredientId = 4, Quantity = 500, UnitOfMeasure = UnitOfMeasure.Gram },  // Ground Beef for Tacos
                new RecipeIngredient { Id = 5, RecipeId = 2, IngredientId = 5, Quantity = 3 },      // Tortillas for Tacos
                
                // Riso cantonese
                new RecipeIngredient {  Id= 6, RecipeId = 3, IngredientId = 6, Quantity = 500, UnitOfMeasure = UnitOfMeasure.Gram},
                new RecipeIngredient {  Id= 7, RecipeId = 3, IngredientId = 7, Quantity = 200, UnitOfMeasure = UnitOfMeasure.Gram},
                new RecipeIngredient {  Id= 8, RecipeId = 3, IngredientId = 8, Quantity = 120, UnitOfMeasure = UnitOfMeasure.Gram},


                // Tiramisù
                new RecipeIngredient { Id = 9, RecipeId = 4, IngredientId = 9, Quantity = 250, UnitOfMeasure = UnitOfMeasure.Gram },
                new RecipeIngredient { Id = 10, RecipeId = 4, IngredientId = 10, Quantity = 1, UnitOfMeasure = UnitOfMeasure.Tablespoon },
                new RecipeIngredient { Id = 11, RecipeId = 4, IngredientId = 11, Quantity = 100, UnitOfMeasure = UnitOfMeasure.Gram }
            );
        }
    }
}
