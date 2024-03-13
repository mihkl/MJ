using System.ComponentModel.DataAnnotations;

namespace MJ.Domain {
    public class Department : Entity {
        public decimal Budget { get; set; }
        public int InstructorId { get; set; }
        public string? Name { get; set; }
        [DataType(DataType.Date)] public DateTime StartDate { get; set; }
    }
}
