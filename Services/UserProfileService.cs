using FitnessTrackingSystem.Models;
using MongoDB.Driver;

namespace FitnessTrackingSystem.Services
{
	public class UserProfileService
	{
		private readonly IMongoCollection<UserProfile> _usersCollection;

		public UserProfileService(IMongoDatabase database)
		{
			_usersCollection = database.GetCollection<UserProfile>("UserProfiles");
		}

		public async Task<UserProfile> GetUserByIdAsync(string id)
		{
			return await _usersCollection.Find(user => user.Id == id).FirstOrDefaultAsync();
		}

		public async Task<List<UserProfile>> GetAllUsersAsync()
		{
			return await _usersCollection.Find(user => true).ToListAsync();
		}

		public async Task CreateUserAsync(UserProfile user)
		{
			await _usersCollection.InsertOneAsync(user);
		}

		public async Task UpdateUserAsync(string id, UserProfile updatedUser)
		{
			await _usersCollection.ReplaceOneAsync(user => user.Id == id, updatedUser);
		}

		public async Task DeleteUserAsync(string id)
		{
			await _usersCollection.DeleteOneAsync(user => user.Id == id);
		}
	}
}
