using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using CondoApi.Domain.Interfaces;
using CondoApi.Domain.Entities;

namespace CondoApi.Api.Features;

[ApiController]
[Route("api/[controller]")]
public class ApartmentController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ApartmentController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/apartment
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var apartments = await _unitOfWork.Apartments.GetAllAsync();
        return Ok(apartments);
    }

    // GET: api/apartment/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var apartment = await _unitOfWork.Apartments.GetByIdAsync(id);
        if (apartment == null) return NotFound();
        return Ok(apartment);
    }

    // POST: api/apartment
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] Apartment apartment)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await _unitOfWork.Apartments.AddAsync(apartment);
        await _unitOfWork.CompleteAsync();
        return CreatedAtAction(nameof(Get), new { id = apartment.Id }, apartment);
    }

    // PUT: api/apartment/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Apartment apartment)
    {
        if (id != apartment.Id) return BadRequest();
        _unitOfWork.Apartments.Update(apartment);
        await _unitOfWork.CompleteAsync();
        return NoContent();
    }

    // DELETE: api/apartment/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var apartment = await _unitOfWork.Apartments.GetByIdAsync(id);
        if (apartment == null) return NotFound();

        _unitOfWork.Apartments.Delete(apartment);
        await _unitOfWork.CompleteAsync();
        return NoContent();
    }
}
