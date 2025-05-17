using CondoApi.Domain.Interfaces;        // ✅ For IUnitOfWork
using CondoApi.Infrastructure;          // ✅ For AppDbContext and UnitOfWork
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Add services to the container
builder.Services.AddControllers();         // ✅ Adds controller support

builder.Services.AddEndpointsApiExplorer(); // ✅ For Swagger/OpenAPI
builder.Services.AddSwaggerGen();

// 🔌 Add DbContext with connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));  // ✅ Using PostgreSQL

// 🧱 Register Unit of Work and Repositories
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// 🔁 Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
