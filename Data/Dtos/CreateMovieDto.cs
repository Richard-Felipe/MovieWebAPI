using System.ComponentModel.DataAnnotations;

namespace MovieWebAPI.Data.Dtos;

public class CreateMovieDto
{
    [Required]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "O Nome deve conter entre 1 à 100 caracteres")]
    public string Name { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "A Categoria deve conter entre 1 à 100 caracteres")]
    public string Category { get; set; }

    [Required]
    [Range(45, 600, ErrorMessage = "O filme deve ser a duração de 45 minutos inicial até 600 minutos finais")]
    public int DurationInMinutes { get; set; }
}
