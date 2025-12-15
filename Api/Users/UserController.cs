using Controllers.Jwt;
using Controllers.Users.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories.User;
using Repositories.User.Repository;

namespace Controllers.Users;

[ApiController]
[Route("credentials")]
public class UserController(ILogger<UserController> logger, IUserWriter userWriter, IPasswordHasher passwordHasher, IJwtToken jwtToken) : ControllerBase
{
    /// <summary>
    /// The GetUsers method retrieves user information based on the provided userId.
    /// </summary>
    /// <param name="userId">The ID of the user to retrieve.</param>
    /// <returns></returns>
    [HttpGet("{userId}")]
    [AllowAnonymous]
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
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] UserDto user, CancellationToken cancellationToken)
    {
        user.Password = passwordHasher.GenerateHash(user.Password);
        var createdUser = await userWriter.Add(user.ToEntity(), cancellationToken);
        var jwt = jwtToken.GenerateJwtToken(createdUser.ToString());
        return Created($"/user/{createdUser}", jwt);
    }
}