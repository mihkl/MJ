
using MJ.Domain;
using MJ.Soft.Data;

namespace MJ.Soft.Controllers;
public class MoviesController(ApplicationDbContext context): BaseController<Movie>(context, context.Movie) {}
