using Api.Models;
using Api.Services.Users.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Create([FromServices] ICreateUserService service, [FromBody] CreateUserRequest request)
    {
        try
        {
            await service.Create(request.Name, request.Email, request.Password);
            return Ok("User created successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [Authorize]
    [HttpGet]
    public async Task<ActionResult> All([FromServices] IGetUsersService service)
    {
        try
        {
            var users = await service.All();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> Get([FromServices] IGetUserService service, int id)
    {
        try
        {
            var user = await service.Get(id);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update([FromServices] IUpdateUserService service, [FromBody] UpdateUserRequest request, int id)
    {
        try
        {
            await service.Update(id, request.Name, request.Email, request.Password);
            return Ok("Updated successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Remove([FromServices] IRemoveUserService service, int id)
    {
        try
        {
            await service.Remove(id);
            return Ok("Removed successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
