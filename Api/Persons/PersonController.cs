using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Persons;

[Authorize]
[ApiController]
[Route("persons")]
public class PersonController : ControllerBase
{
    [Authorize]
    [HttpGet]
    public IActionResult GetPerson()
    {
        return Ok("Person");
    }

    [Authorize]
    [HttpPost]
    public IActionResult PostPerson()
    {
        return Ok();
    }
}
