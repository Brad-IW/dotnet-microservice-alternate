using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UserAPI.Models;
using UserAPI.Repositories;

namespace UserAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await _userRepository.GetUser(id);
        
        if (user is null)
        {
            return new BadRequestObjectResult($"User with id '{id}' not found.");
        }

        var json = JsonConvert.SerializeObject(user);
        return new OkObjectResult(json);
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userRepository.GetUsers();
        var json = JsonConvert.SerializeObject(users);

        return new OkObjectResult(json);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        var res = await _userRepository.CreateUser(user);

        if (res is null)
        {
            return new BadRequestObjectResult($"User with id '{user.Id}' already exists.");
        }

        return StatusCode(StatusCodes.Status201Created, user);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] User user)
    {
        var res = await _userRepository.UpdateUser(user);

        if (res is null)
        {
            return new BadRequestObjectResult($"User with id '{user.Id}' does not exist.");
        }

        return StatusCode(StatusCodes.Status200OK, user);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        _userRepository.DeleteUser(id);
        return StatusCode(StatusCodes.Status200OK);
    }

}
