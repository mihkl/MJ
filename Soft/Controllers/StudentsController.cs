using MJ.Domain;
using MJ.Soft.Data;

namespace MJ.Soft.Controllers;

public class StudentsController(ApplicationDbContext context): BaseController<Student>(context, context.Students) { }