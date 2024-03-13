using System.ComponentModel.DataAnnotations;

namespace MJ.Domain {
    public class Student : Person {
        [DataType(DataType.Date)]public DateTime EnrollmentDate { get; set; }
    }
}
