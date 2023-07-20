using Microsoft.EntityFrameworkCore;
using MovieWebAPI.Models;

namespace MovieWebAPI.Data;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> opts) : base(opts) { }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Theater> Theaters { get; set; }
    public DbSet<Address> Adresses { get; set; }
}
