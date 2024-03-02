using System.ComponentModel.DataAnnotations;

namespace MJ.Domain;

public class Person : Entity{
    
    public string? FirstName { get; set; }
    public string? FamilyName { get; set; }
    [DataType(DataType.Date)] public DateTime DoB { get; set; }
    public bool Gender { get; set; }

}
