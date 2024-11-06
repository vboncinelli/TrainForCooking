
using TrainForCooking.Repository.EF;

//var categoryRepo = new CategoryRepository();

//var entity = categoryRepo.GetAll();

var recipeRepo = new RecipeRepository();

var recipes = recipeRepo.GetRecipesByCategoryId(1, 1, 20);

//var entity = recipeRepo.Find(1);



Console.ReadKey();

