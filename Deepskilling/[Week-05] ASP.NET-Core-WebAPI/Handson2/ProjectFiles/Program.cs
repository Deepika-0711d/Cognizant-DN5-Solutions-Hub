using EmployeeAPI.Data;
using EmployeeAPI.Services;
using Microsoft.EntityFrameworkCore;

var appBuilder = WebApplication.CreateBuilder(args);

appBuilder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("EmployeeDB"));

appBuilder.Services.AddControllers();
appBuilder.Services.AddEndpointsApiExplorer();
appBuilder.Services.AddSwaggerGen();
appBuilder.Services.AddScoped<EmployeeService>();

var webApp = appBuilder.Build();

// Initialize database with seed data
using (var scope = webApp.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
}

if (webApp.Environment.IsDevelopment())
{
    webApp.UseSwagger();
    webApp.UseSwaggerUI();
}

webApp.UseHttpsRedirection();
webApp.UseAuthorization();
webApp.MapControllers();

webApp.Run();
