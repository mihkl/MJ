using System.ComponentModel.DataAnnotations;

namespace MJ.Domain;

public class Movie : Entity{
   
    public string? Title { get; set; }
    [DataType(DataType.Date)] public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }
    public decimal Price { get; set; }
}
