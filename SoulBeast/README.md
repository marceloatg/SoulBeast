#CRIANDO UMA API COM ENTITY FRAMEWORK

# 1- Instalar os Pacotes:
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.InMemory
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools


# 2- Criar a pasta Models onde vai ficar as entidades, Ex:

public class SoulBeast
{
public int IdSoulBeast { get; set; }
public string SoulBeastName { get; set; }
public int Level { get; set; }
public string Type { get; set; }
}

# 3- Criar a pasta Data onde vai ficar o DbContext, Ex:

using Microsoft.EntityFrameworkCore;
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

# 4- Adicionar o services do DbContext no Progam.cs, ex:
builder.Services.AddDbContext<SoulBeastAPIDbContext>(options => options.UseInMemoryDatabase("SoulBeastDb"));

# 5- Criar a pasta Controllers e a classe Controller, ex:



# 6- Criar DbContextFactory e ajustar a connectionstring no appsettings.json.
#Criar a migrations:
dotnet ef migrations add InitialCreate -p SoulBeast
dotnet ef database update -p SoulBeast
dotnet ef database drop -f -p SoulBeast

(Caso precise deletar: dotnet ef database drop SoulBeast)

# 7- Adicionar no Program.cs a variavel para leitura do connectionString ex:
var connectionString = builder.Configuration.GetConnectionString("SqlServer");

builder.Services.AddDbContext<SoulBeastAPIDbContext>(options =>
options.UseSqlServer(connectionString)
);
