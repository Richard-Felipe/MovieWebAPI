using System.ComponentModel.DataAnnotations;

namespace MovieWebAPI.Data.Dtos;

public class CreateAddressDto
{
    [Required]
    public string PublicPlace { get; set; }
    [Required]
    public int NumberAddress { get; set; }
}
