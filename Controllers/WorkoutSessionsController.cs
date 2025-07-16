using FitnessTrackingSystem.Models;
using FitnessTrackingSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WorkoutSessionsController : ControllerBase
	{
		private readonly WorkoutSessionService _workoutSessionService;

		public WorkoutSessionsController(WorkoutSessionService workoutSessionService)
		{
			_workoutSessionService = workoutSessionService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateWorkout([FromBody] WorkoutSession workoutSession)
		{
			await _workoutSessionService.CreateWorkoutAsync(workoutSession);
			return CreatedAtAction(nameof(GetWorkoutById), new { id = workoutSession.Id }, workoutSession);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetWorkoutById(string id)
		{
			var workout = await _workoutSessionService.GetWorkoutByIdAsync(id);
			if (workout == null) return NotFound();
			return Ok(workout);
		}

		[HttpGet("user/{userId}")]
		public async Task<IActionResult> GetWorkoutsByUserId(string userId)
		{
			var workouts = await _workoutSessionService.GetWorkoutsByUserIdAsync(userId);
			return Ok(workouts);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateWorkout(string id, [FromBody] WorkoutSession workoutSession)
		{
			await _workoutSessionService.UpdateWorkoutAsync(id, workoutSession);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteWorkout(string id)
		{
			await _workoutSessionService.DeleteWorkoutAsync(id);
			return NoContent();
		}
	}
}
