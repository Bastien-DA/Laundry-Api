using Api.Jwt;
using Api.Users.Dto;
using Infrastructure.User;
using Infrastructure.User.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Users;

[ApiController]
[Route("credentials")]
public class UserController(ILogger<UserController> logger, IUserWriter userWriter, IPasswordHasher passwordHasher, IJwtToken jwtToken) : ControllerBase
{
}