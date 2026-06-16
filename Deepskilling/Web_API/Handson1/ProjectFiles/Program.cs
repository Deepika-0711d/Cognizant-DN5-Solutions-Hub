using StudentAPI.Services;

var builderApp = WebApplication.CreateBuilder(args);

builderApp.Services.AddControllers();
builderApp.Services.AddEndpointsApiExplorer();
builderApp.Services.AddSwaggerGen();
builderApp.Services.AddScoped<StudentService>();

var appInstance = builderApp.Build();

if (appInstance.Environment.IsDevelopment())
{
    appInstance.UseSwagger();
    appInstance.UseSwaggerUI();
}

appInstance.UseHttpsRedirection();
appInstance.UseAuthorization();
appInstance.MapControllers();

appInstance.Run();
