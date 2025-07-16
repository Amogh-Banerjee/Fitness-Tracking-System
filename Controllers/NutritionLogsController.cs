using FitnessTrackingSystem.Models;
using FitnessTrackingSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NutritionLogsController : ControllerBase
	{
		private readonly NutritionLogService _nutritionLogService;

		public NutritionLogsController(NutritionLogService nutritionLogService)
		{
			_nutritionLogService = nutritionLogService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateNutritionLog([FromBody] NutritionLog nutritionLog)
		{
			await _nutritionLogService.CreateNutritionLogAsync(nutritionLog);
			return CreatedAtAction(nameof(GetNutritionLogById), new { id = nutritionLog.Id }, nutritionLog);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetNutritionLogById(string id)
		{
			var log = await _nutritionLogService.GetNutritionLogByIdAsync(id);
			if (log == null) return NotFound();
			return Ok(log);
		}

		[HttpGet("user/{userId}")]
		public async Task<IActionResult> GetNutritionLogsByUserId(string userId)
		{
			var logs = await _nutritionLogService.GetNutritionLogsByUserIdAsync(userId);
			return Ok(logs);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateNutritionLog(string id, [FromBody] NutritionLog nutritionLog)
		{
			await _nutritionLogService.UpdateNutritionLogAsync(id, nutritionLog);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteNutritionLog(string id)
		{
			await _nutritionLogService.DeleteNutritionLogAsync(id);
			return NoContent();
		}
	}
}