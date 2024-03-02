using System.ComponentModel.DataAnnotations;

namespace MJ.Soft.Models;

public class Person {
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? FamilyName { get; set; }
    [DataType(DataType.Date)] public DateTime DoB { get; set; }
    public bool Gender { get; set; }
    
}
