using Microsoft.AspNetCore.Mvc;
using MJ.Soft.Data;

namespace MJ.Soft.Controllers;

public class BaseController(ApplicationDbContext context): Controller {
    protected readonly ApplicationDbContext c = context;
}
