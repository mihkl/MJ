using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MJ.Domain;

namespace MJ.Soft.Data {
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Student> Students { get; set; } = default !;
        public DbSet<Instructor> Instructors { get; set; } = default!;
        public DbSet<Department> Departments { get; set; } = default!;
        public DbSet<Course> Courses { get; set; } = default!;


    }
}
