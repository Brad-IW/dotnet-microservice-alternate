using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace UserAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UsersContext _usersContext;

    public UsersController(UsersContext usersContext)
    {
        _usersContext = usersContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _usersContext.Users.ToListAsync();
        var json = JsonConvert.SerializeObject(users);

        return new OkObjectResult(json);
    }
}
