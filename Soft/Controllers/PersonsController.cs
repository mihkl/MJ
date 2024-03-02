
using MJ.Domain;
using MJ.Soft.Data;

namespace MJ.Soft.Controllers;

public class PersonsController(ApplicationDbContext context): BaseController<Person>(context, context.Persons) { }
