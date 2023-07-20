using System.ComponentModel.DataAnnotations;

namespace MovieWebAPI.Data.Dtos;

public class CreateTheaterDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int AddressId { get; set; }
}
