
using TrainForCooking.Repository.EF;

var repo = new CategoryRepository();

var entity = repo.GetAll();

Console.ReadKey();