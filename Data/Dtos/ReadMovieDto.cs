namespace MovieWebAPI.Data.Dtos;

public class ReadMovieDto
{
    public string Name { get; set; }
    public string Category { get; set; }
    public int DurationInMinutes { get; set; }
    public DateTime SearchTime { get; set; } = DateTime.Now;
}
