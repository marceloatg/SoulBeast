using Microsoft.AspNetCore.Mvc;
using SoulBeast.Data;

namespace Owner.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OwnerController : Controller
{
    private readonly SoulBeastAPIDbContext _dbContext;

    public OwnerController(SoulBeastAPIDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // GET
    [HttpGet]
    public IActionResult Owner()
    {
        return Ok(_dbContext.Owners.ToList());
    }
}
