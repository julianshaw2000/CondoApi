using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using CondoApi.Domain.Interfaces;
using CondoApi.Domain.Entities;


namespace CondoApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public UserController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/user
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _unitOfWork.Users.GetAllAsync(); // ✅ await here
        return Ok(users);
    }

    // GET: api/user/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id); // ✅ await here
        if (user == null) return NotFound();
        return Ok(user);
    }

    // GET: api/user/by-email/{email}
    [HttpGet("byemail/{email}")]
    public async Task<IActionResult> GetByEmail(string email)
    {
        var user = await _unitOfWork.Users.GetUserByEmailAsync(email);
        if (user == null) return NotFound();
        return Ok(user);
    }

    // POST: api/user
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] User user)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await _unitOfWork.Users.AddAsync(user);
        await _unitOfWork.CompleteAsync();
        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }

    // PUT: api/user/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] User user)
    {
        if (id != user.Id) return BadRequest();
        _unitOfWork.Users.Update(user);
        await _unitOfWork.CompleteAsync();
        return NoContent();
    }

    // DELETE: api/user/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id); // ✅ await here
        if (user == null) return NotFound();

        _unitOfWork.Users.Delete(user);
        await _unitOfWork.CompleteAsync();
        return NoContent();
    }
}
