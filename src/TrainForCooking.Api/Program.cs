using System.Text.Json.Serialization;
using TrainForCooking.Common;
using TrainForCooking.Interfaces;
using TrainForCooking.Repository.EF;
namespace TrainForCooking.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
            
            builder.Services
                .AddControllers()
                .AddJsonOptions(x =>
            {
                // serialize enums as strings in api responses (e.g. Role)
                //x
                //.JsonSerializerOptions
                //.Converters
                //.Add(new JsonStringEnumConverter());
            });


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}
