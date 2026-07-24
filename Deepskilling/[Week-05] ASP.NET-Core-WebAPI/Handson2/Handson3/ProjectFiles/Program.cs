using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ProductAPI.Services;
using System.Text;

var appBuilder = WebApplication.CreateBuilder(args);

var secretKey = "YourSuperSecretKeyWithAtLeast32CharactersForHS256";
var keyBytes = Encoding.ASCII.GetBytes(secretKey);

appBuilder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = true,
        ValidIssuer = "YourAppIssuer",
        ValidateAudience = true,
        ValidAudience = "YourAppAudience",
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

appBuilder.Services.AddControllers();
appBuilder.Services.AddEndpointsApiExplorer();
appBuilder.Services.AddSwaggerGen();
appBuilder.Services.AddScoped<AuthService>();
appBuilder.Services.AddScoped<JwtService>();
appBuilder.Services.AddScoped<ProductService>();

var webApp = appBuilder.Build();

if (webApp.Environment.IsDevelopment())
{
    webApp.UseSwagger();
    webApp.UseSwaggerUI();
}

webApp.UseHttpsRedirection();
webApp.UseAuthentication();
webApp.UseAuthorization();
webApp.MapControllers();

webApp.Run();
