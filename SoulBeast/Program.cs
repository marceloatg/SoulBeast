using Microsoft.EntityFrameworkCore;
using SoulBeast.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Lendo valor do connectionString para essa var.
var connectionString = builder.Configuration.GetConnectionString("PostgreSQL");

//Adicionando Services do DbContext com o Database API
builder.Services.AddDbContext<SoulBeastAPIDbContext>(options =>
    options.UseNpgsql(connectionString)
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
