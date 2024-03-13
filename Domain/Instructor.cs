using System.ComponentModel.DataAnnotations;

namespace MJ.Domain {
    public class Instructor : Person{

        [DataType(DataType.Date)] public DateTime HireDate { get; set; }
    }
}
