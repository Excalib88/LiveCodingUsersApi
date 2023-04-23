using Microsoft.AspNetCore.Mvc;
using WebApi.App.Logic;
using WebApi.App.Models;

namespace WebApi.App.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAuditService _auditService;

    public UsersController(IUserService userService, IAuditService auditService)
    {
        _userService = userService;
        _auditService = auditService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery]AuthorizeRequest request)
    {
        await _auditService.Log(request.Email);
        var users = await _userService.GetAll(request);
        
        return Ok(new {data = users});
    }
}