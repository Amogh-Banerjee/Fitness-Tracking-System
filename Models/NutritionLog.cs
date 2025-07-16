namespace FitnessTrackingSystem.Models
{
	public class NutritionLog
	{
		public string Id { get; set; }
		public string UserId { get; set; }
		public DateTime Date { get; set; }
		public string FoodItem { get; set; }
		public int Calories { get; set; }
	}
}