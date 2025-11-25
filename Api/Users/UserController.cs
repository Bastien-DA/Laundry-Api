using Controllers.Users.Dto;
using Controllers.Users.Mapping;
using Microsoft.AspNetCore.Mvc;
using Repositories.User;
using Repositories.User.Repository;

namespace Controllers.Users;

[ApiController]
[Route("user")]
public class UserController(ILogger<UserController> logger, IWriter userWriter, IPasswordHasher passwordHasher) : ControllerBase
{ 
    private readonly ILogger<UserController> _logger = logger;
    private readonly IWriter _userWriter = userWriter;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;
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
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateUser([FromBody] UserDto user, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating user with name {UserName}", user);
        _userWriter.Add(UserMapping.ToEntity(user), cancellationToken);
        return NoContent();
    }
}