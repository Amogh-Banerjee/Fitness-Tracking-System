
using FitnessTrackingSystem.Services;
using MongoDB.Driver;
using System.Runtime;

namespace FitnessTrackingSystem
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Load configuration for MongoDB
			builder.Services.Configure<FitnessTrackingDbSettings>(
				builder.Configuration.GetSection(nameof(FitnessTrackingDbSettings)));

			builder.Services.AddSingleton<IMongoClient>(s =>
				new MongoClient(builder.Configuration.GetValue<string>("DbSettings:ConnectionString")));

			builder.Services.AddSingleton<IMongoDatabase>(s =>
				s.GetRequiredService<IMongoClient>().GetDatabase(builder.Configuration.GetValue<string>("DbSettings:DatabaseName")));

			// Register services
			builder.Services.AddScoped<UserProfileService>();
			builder.Services.AddScoped<WorkoutSessionService>();
			builder.Services.AddScoped<NutritionLogService>();

			// Add services and controllers
			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure middleware and endpoints
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseRouting();
			app.UseAuthorization();
			app.MapControllers();

			app.Run();

		}
	}
}
