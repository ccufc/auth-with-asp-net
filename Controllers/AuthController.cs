using Api.Models;
using Api.Services.Auth.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Login([FromServices] ILoginService service, [FromBody] LoginRequest request)
    {
        try
        {
            var (token, user) = await service.Login(request.Email, request.Password);
            return Ok(new { Token = token, User = user });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
