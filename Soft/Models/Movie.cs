using System.ComponentModel.DataAnnotations;

namespace MJ.Soft.Models;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }
    [DataType(DataType.Date)] public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }
    public decimal Price { get; set; }
}

public class Person {
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? FamilyName { get; set; }
    [DataType(DataType.Date)] public DateTime DoB { get; set; }
    public bool Gender { get; set; }
    
}
