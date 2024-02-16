using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MJ.Soft.Models;

namespace MJ.Soft.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<MJ.Soft.Models.Movie> Movie { get; set; } = default!;
    }
}
