using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MJ.Domain;

namespace MJ.Soft.Data {
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Movie> Movie { get; set; } = default!;

        public DbSet<Person> Persons { get; set; } = default!;
    }
}
