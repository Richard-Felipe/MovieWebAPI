using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MovieWebAPI.Data.Dtos;
using MovieWebAPI.Data;
using MovieWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieWebAPI.Controllers;

[ApiController]
public class AddressController : ControllerBase
{
    private readonly MovieContext _context;
    private readonly IMapper _mapper;

    public AddressController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("adresses")]
    public IEnumerable<ReadAddressDto> Get() => _mapper.Map<List<ReadAddressDto>>(_context.Adresses.ToList());

    [HttpGet("adresses/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var address = await _context.Adresses.FirstOrDefaultAsync(a => a.Id == id);

        if (address is null)
            return NotFound();

        return Ok(_mapper.Map<ReadAddressDto>(address));
    }

    [HttpPost("adresses")]
    public async Task<IActionResult> Post([FromRoute] int id, [FromBody] CreateAddressDto model)
    {
        var address = _mapper.Map<Address>(model);

        await _context.Adresses.AddAsync(address);
        await _context.SaveChangesAsync();

        return Created($"adresses/{address.Id}", model);
    }

    [HttpPut("adresses/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAddressDto model)
    {
        var address = await _context.Adresses.FirstOrDefaultAsync(a => a.Id == id);

        if (address is null)
            return NotFound();

        _context.Adresses.Update(_mapper.Map(model, address));
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPatch("adresses/{id:int}")]
    public async Task<IActionResult> Patch([FromRoute] int id, [FromBody] JsonPatchDocument<UpdateAddressDto> patch)
    {
        var address = await _context.Adresses.FirstOrDefaultAsync(a => a.Id == id);

        if (address is null)
            return NotFound();

        var addressUpdated = _mapper.Map<UpdateAddressDto>(address);

        patch.ApplyTo(addressUpdated, ModelState);
        if (!TryValidateModel(addressUpdated))
            return ValidationProblem(ModelState);

        _context.Adresses.Update(_mapper.Map(addressUpdated, address));
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("adresses/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var address = await _context.Adresses.FirstOrDefaultAsync(a => a.Id == id);

        if (address is null)
            return NotFound();

        _context.Adresses.Remove(address);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}
