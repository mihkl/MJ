using MJ.Domain;
using MJ.Soft.Data;

namespace MJ.Soft.Controllers;

public class CoursesController(ApplicationDbContext context): BaseController<Course>(context, context.Courses) { }