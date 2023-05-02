using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoulBeast.Data;
using SoulBeast.Models;

namespace SoulBeast.Controllers;

[ApiController]
[Route("api/SoulBeast")]
public class SoulBeastController : Controller
{
    private readonly SoulBeastAPIDbContext dbContext;

    public SoulBeastController(SoulBeastAPIDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetSoulBeasts()
    {
        return Ok(await dbContext.SoulBeasts.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> AddSoulBeast(AddSoulBeastRequest addSoulBeastRequest)
    {
        var soulbeast = new Models.SoulBeast()
        {
            Id = Guid.NewGuid(),
            Name = addSoulBeastRequest.Name,
            Level = addSoulBeastRequest.Level,
            Type = addSoulBeastRequest.Type
        };

        await dbContext.SoulBeasts.AddAsync(soulbeast);

        return Ok(soulbeast);
    }
}
