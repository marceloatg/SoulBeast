using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SoulBeast.Models;

namespace SoulBeast.Data;

public class SoulBeastAPIDbContext : DbContext
{
    public SoulBeastAPIDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Models.SoulBeast> SoulBeasts { get; set; }
    public DbSet<Owner> Owners { get; set; }
}
