using FitnessTrackingSystem.Models;
using MongoDB.Driver;

namespace FitnessTrackingSystem.Services
{
	public class NutritionLogService
	{
		private readonly IMongoCollection<NutritionLog> _nutritionCollection;

		public NutritionLogService(IMongoDatabase database)
		{
			_nutritionCollection = database.GetCollection<NutritionLog>("NutritionLogs");
		}

		public async Task<NutritionLog> GetNutritionLogByIdAsync(string id)
		{
			return await _nutritionCollection.Find(log => log.Id == id).FirstOrDefaultAsync();
		}

		public async Task<List<NutritionLog>> GetNutritionLogsByUserIdAsync(string userId)
		{
			return await _nutritionCollection.Find(log => log.UserId == userId).ToListAsync();
		}

		public async Task CreateNutritionLogAsync(NutritionLog log)
		{
			await _nutritionCollection.InsertOneAsync(log);
		}

		public async Task UpdateNutritionLogAsync(string id, NutritionLog updatedLog)
		{
			await _nutritionCollection.ReplaceOneAsync(log => log.Id == id, updatedLog);
		}

		public async Task DeleteNutritionLogAsync(string id)
		{
			await _nutritionCollection.DeleteOneAsync(log => log.Id == id);
		}
	}
}