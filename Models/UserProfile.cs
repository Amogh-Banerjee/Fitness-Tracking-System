namespace FitnessTrackingSystem.Models
{
	public class UserProfile
	{
		public string Id { get; set; }  
		public string Name { get; set; }
		public int Age { get; set; }
		public List<FitnessGoal> FitnessGoals { get; set; }
	}

	public class FitnessGoal
	{
		public string Goal { get; set; }
		public DateTime TargetDate { get; set; }
	}
}
