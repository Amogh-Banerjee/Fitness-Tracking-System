namespace FitnessTrackingSystem.Models
{
	public class WorkoutSession
	{
		public string Id { get; set; }
		public string UserId { get; set; }
		public DateTime Date { get; set; }
		public string Exercise { get; set; }
		public int Duration { get; set; } // in minutes
	}
}