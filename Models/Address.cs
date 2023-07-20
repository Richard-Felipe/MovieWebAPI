namespace MovieWebAPI.Models;

public class Address
{
    public int Id { get; set; }
    public string PublicPlace { get; set; }
    public int NumberAddress { get; set; }
    public virtual Theater Theater { get; set; }
}
