using Controllers.Jwt;
using Controllers.Users.Dto;
using Controllers.Users.Mapping;
using Microsoft.AspNetCore.Mvc;
using Repositories.User;
using Repositories.User.Repository;

namespace Controllers.Users;

[ApiController]
[Route("credentials")]
public class UserController(ILogger<UserController> logger, IWriter userWriter, IPasswordHasher passwordHasher, IJwtToken jwtToken) : ControllerBase
{
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
        logger.LogInformation("Getting user with id {UserId}", userId);
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
    public async Task<IActionResult> Register([FromBody] UserDto user, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating user with name {UserName}", user);
        user.Password = passwordHasher.GenerateHash(user.Password);
        var createdUser = await userWriter.Add(UserMapping.ToEntity(user), cancellationToken);
        var jwt = new JwtDto { Token = jwtToken.GenerateJwtToken(createdUser.ToString()) };
        return Created($"/user/{createdUser}", jwt);    
    }
}