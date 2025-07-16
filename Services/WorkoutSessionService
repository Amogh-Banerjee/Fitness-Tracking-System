using FitnessTrackingSystem.Models;
using MongoDB.Driver;

namespace FitnessTrackingSystem.Services
{
	public class WorkoutSessionService
	{
		private readonly IMongoCollection<WorkoutSession> _workoutsCollection;

		public WorkoutSessionService(IMongoDatabase database)
		{
			_workoutsCollection = database.GetCollection<WorkoutSession>("WorkoutSessions");
		}

		public async Task<WorkoutSession> GetWorkoutByIdAsync(string id)
		{
			return await _workoutsCollection.Find(session => session.Id == id).FirstOrDefaultAsync();
		}

		public async Task<List<WorkoutSession>> GetWorkoutsByUserIdAsync(string userId)
		{
			return await _workoutsCollection.Find(session => session.UserId == userId).ToListAsync();
		}

		public async Task CreateWorkoutAsync(WorkoutSession workout)
		{
			await _workoutsCollection.InsertOneAsync(workout);
		}

		public async Task UpdateWorkoutAsync(string id, WorkoutSession updatedWorkout)
		{
			await _workoutsCollection.ReplaceOneAsync(session => session.Id == id, updatedWorkout);
		}

		public async Task DeleteWorkoutAsync(string id)
		{
			await _workoutsCollection.DeleteOneAsync(session => session.Id == id);
		}
	}
}
