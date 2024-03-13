using MJ.Domain;
using MJ.Soft.Data;

namespace MJ.Soft.Controllers;

public class DepartmentsController(ApplicationDbContext context): BaseController<Department>(context, context.Departments) { }