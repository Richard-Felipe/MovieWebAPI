using System.ComponentModel.DataAnnotations;

namespace MovieWebAPI.Data.Dtos;

public class UpdateTheaterDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int AddressId { get; set; }
}
