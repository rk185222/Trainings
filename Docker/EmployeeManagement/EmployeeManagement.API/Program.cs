using EmployeeManagement.API.Models;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User Id=sa;Password={dbPassword}";
builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(connectionString));
//builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDBConnection")));

builder.Services.AddTransient<IEmployeeRepository, SQLEmployeeRepository>();
//builder.Services.AddTransient<IEmployeeRepository, MockEmployeeRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<AppDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
