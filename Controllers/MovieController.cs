using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieWebAPI.Data;
using MovieWebAPI.Data.Dtos;
using MovieWebAPI.Models;

namespace MovieWebAPI.Controllers;

[ApiController]
public class MovieController : ControllerBase
{
    private readonly MovieContext _context;
    private readonly IMapper _mapper;

    public MovieController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("movies")]
    public IEnumerable<ReadMovieDto> Get() => _mapper.Map<List<ReadMovieDto>>(_context.Movies.AsNoTracking().ToList());

    [HttpGet("movies/{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.Id == id);

        if (movie is null)
            return NotFound();

        return Ok(_mapper.Map<ReadMovieDto>(movie));
    }

    [HttpPost("movies")]
    public async Task<IActionResult> Post([FromBody] CreateMovieDto model)
    {
        var movie = _mapper.Map<Movie>(model);

        await _context.Movies.AddAsync(movie);
        await _context.SaveChangesAsync();

        return Created($"movies/{movie.Id}", model);
    }

    [HttpPut("movies/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMovieDto model)
    {
        var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

        if (movie is null)
            return NotFound();

        _context.Movies.Update(_mapper.Map(model, movie));
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPatch("movies/{id:int}")]
    public async Task<IActionResult> Patch([FromRoute] int id, [FromBody] JsonPatchDocument<UpdateMovieDto> patch)
    {
        var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

        if (movie is null)
            return NotFound();

        var movieUpdated = _mapper.Map<UpdateMovieDto>(movie);

        patch.ApplyTo(movieUpdated, ModelState);
        
        if (!TryValidateModel(movieUpdated))
            return ValidationProblem(ModelState);

        _context.Movies.Update(_mapper.Map(movieUpdated, movie));
        await _context.SaveChangesAsync();

        return NoContent();
    }    

    [HttpDelete("movies/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

        if (movie is null)
            return NotFound();

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
