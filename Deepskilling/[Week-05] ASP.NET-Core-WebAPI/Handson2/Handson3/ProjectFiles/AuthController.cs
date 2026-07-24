using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Services;

namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService authSvc;
        private readonly JwtService jwtSvc;

        public AuthController()
        {
            authSvc = new AuthService();
            jwtSvc = new JwtService();
        }

        [HttpPost("login")]
        public ActionResult<AuthResponse> Login([FromBody] LoginRequest loginData)
        {
            if (loginData == null || string.IsNullOrEmpty(loginData.email) || string.IsNullOrEmpty(loginData.password))
                return BadRequest(new AuthResponse { success = false, message = "Email and password required" });

            var userRecord = authSvc.ValidateUser(loginData.email, loginData.password);
            if (userRecord == null)
                return Unauthorized(new AuthResponse { success = false, message = "Invalid email or password" });

            var token = jwtSvc.GenerateToken(userRecord);
            return Ok(new AuthResponse
            {
                success = true,
                message = "Login successful",
                token = token,
                user = userRecord
            });
        }

        [HttpPost("register")]
        public ActionResult<AuthResponse> Register([FromBody] LoginRequest registerData)
        {
            if (string.IsNullOrEmpty(registerData.email) || string.IsNullOrEmpty(registerData.password))
                return BadRequest(new AuthResponse { success = false, message = "Email and password required" });

            var newUser = authSvc.RegisterNewUser("NewUser", registerData.email, registerData.password);
            if (newUser == null)
                return BadRequest(new AuthResponse { success = false, message = "Email already registered" });

            var token = jwtSvc.GenerateToken(newUser);
            return Ok(new AuthResponse
            {
                success = true,
                message = "Registration successful",
                token = token,
                user = newUser
            });
        }
    }
}
