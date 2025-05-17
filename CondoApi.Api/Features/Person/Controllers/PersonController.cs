using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using CondoApi.Domain.Interfaces;
using CondoApi.Domain.Entities;

namespace CondoApi.Api.Features;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public PersonController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/person
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var people = await _unitOfWork.Persons.GetAllAsync();
        return Ok(people);
    }

    // GET: api/person/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var person = await _unitOfWork.Persons.GetByIdAsync(id);
        if (person == null) return NotFound();
        return Ok(person);
    }

    // GET: api/person/byemail/{email}
    [HttpGet("byemail/{email}")]
    public async Task<IActionResult> GetByEmail(string email)
    {
        var person = await _unitOfWork.Persons.GetPersonByEmailAsync(email);
        if (person == null) return NotFound();
        return Ok(person);
    }

    // POST: api/person
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] Person person)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await _unitOfWork.Persons.AddAsync(person);
        await _unitOfWork.CompleteAsync();
        return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
    }

    // PUT: api/person/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Person person)
    {
        if (id != person.Id) return BadRequest();
        _unitOfWork.Persons.Update(person);
        await _unitOfWork.CompleteAsync();
        return NoContent();
    }

    // DELETE: api/person/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var person = await _unitOfWork.Persons.GetByIdAsync(id);
        if (person == null) return NotFound();

        _unitOfWork.Persons.Delete(person);
        await _unitOfWork.CompleteAsync();
        return NoContent();
    }
}
