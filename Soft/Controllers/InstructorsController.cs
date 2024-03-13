using MJ.Domain;
using MJ.Soft.Data;

namespace MJ.Soft.Controllers;

public class InstructorsController(ApplicationDbContext context): BaseController<Instructor>(context, context.Instructors) { }