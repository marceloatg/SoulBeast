using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SoulBeast.Data;

public class SoulBeastFactory : IDesignTimeDbContextFactory<SoulBeastAPIDbContext>
{
    public SoulBeastAPIDbContext CreateDbContext(string[] args)
        {
            var connectionString = "Host=localhost;Database=SoulBeast;Username=postgres;Password=3cbad3bca063473b990948c63086ecac";
            var optionsBuilder = new DbContextOptionsBuilder<SoulBeastAPIDbContext>();
            optionsBuilder.UseNpgsql(connectionString);
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);

            return new(optionsBuilder.Options);
        }
}
