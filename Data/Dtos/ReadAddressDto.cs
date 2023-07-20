using MovieWebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieWebAPI.Data.Dtos;

public class ReadAddressDto
{
    public string PublicPlace { get; set; }
    public int NumberAddress { get; set; }
    public Theater TheaterDto { get; set; }
}
