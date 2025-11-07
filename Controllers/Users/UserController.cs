using Controllers.Users.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Users;

[ApiController]
[Route("user")]
public class UserController(ILogger<UserController> logger) : ControllerBase
{ 
    private readonly ILogger<UserController> _logger = logger;
    
    /// <summary>
    /// The GetUsers method retrieves user information based on the provided userId.
    /// </summary>
    /// <param name="userId">The ID of the user to retrieve.</param>
    /// <returns></returns>
    [HttpGet("{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetUser(int userId)
    {
        _logger.LogInformation("Getting user with id {UserId}", userId);
        return Ok($"User{userId}");
    }

    /// <summary>
    /// The CreateUser method creates a new user with the provided userName.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateUser([FromBody] UserDto user)
    {
        _logger.LogInformation("Creating user with name {UserName}", user);
        return CreatedAtAction(nameof(GetUser), new { userId = 1 }, $"User1: {user}");
    }
}