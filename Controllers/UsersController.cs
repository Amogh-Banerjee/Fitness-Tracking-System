using FitnessTrackingSystem.Models;
using FitnessTrackingSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly UserProfileService _userProfileService;

		public UsersController(UserProfileService userProfileService)
		{
			_userProfileService = userProfileService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateUser([FromBody] UserProfile userProfile)
		{
			await _userProfileService.CreateUserAsync(userProfile);
			return CreatedAtAction(nameof(GetUserById), new { id = userProfile.Id }, userProfile);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetUserById(string id)
		{
			var user = await _userProfileService.GetUserByIdAsync(id);
			if (user == null) return NotFound();
			return Ok(user);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllUsers()
		{
			var users = await _userProfileService.GetAllUsersAsync();
			return Ok(users);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateUser(string id, [FromBody] UserProfile userProfile)
		{
			await _userProfileService.UpdateUserAsync(id, userProfile);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUser(string id)
		{
			await _userProfileService.DeleteUserAsync(id);
			return NoContent();
		}
	}
}
