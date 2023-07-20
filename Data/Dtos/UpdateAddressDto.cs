using System.ComponentModel.DataAnnotations;

namespace MovieWebAPI.Data.Dtos;

public class UpdateAddressDto
{
    [Required]
    public string PublicPlace { get; set; }
    [Required]
    public int NumberAddress { get; set; }
}
