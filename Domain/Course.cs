namespace MJ.Domain {
    public class Course : Entity {
        public int Credits { get; set; }
        public string? DepartmentId { get; set; }
        public string? Title { get; set; }
    }
}
