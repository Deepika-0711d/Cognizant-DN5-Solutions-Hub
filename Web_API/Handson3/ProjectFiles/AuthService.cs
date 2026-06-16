using ProductAPI.Models;
using System.Security.Cryptography;
using System.Text;

namespace ProductAPI.Services
{
    public class AuthService
    {
        private static List<User> registeredUsers = new List<User>
        {
            new User { userId = 1, userName = "Admin", userEmail = "admin@company.com", userPassword = HashPassword("Admin@123"), userRole = "Admin", createdAt = DateTime.Now },
            new User { userId = 2, userName = "Rajesh", userEmail = "rajesh@company.com", userPassword = HashPassword("Rajesh@123"), userRole = "User", createdAt = DateTime.Now }
        };

        public User ValidateUser(string email, string password)
        {
            var userRecord = registeredUsers.FirstOrDefault(u => u.userEmail == email);
            if (userRecord == null)
                return null;

            if (!VerifyPassword(password, userRecord.userPassword))
                return null;

            return userRecord;
        }

        public User RegisterNewUser(string name, string email, string password)
        {
            if (registeredUsers.Any(u => u.userEmail == email))
                return null;

            var newUser = new User
            {
                userId = registeredUsers.Count > 0 ? registeredUsers.Max(u => u.userId) + 1 : 1,
                userName = name,
                userEmail = email,
                userPassword = HashPassword(password),
                userRole = "User",
                createdAt = DateTime.Now
            };

            registeredUsers.Add(newUser);
            return newUser;
        }

        private static string HashPassword(string plainPassword)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(plainPassword));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private static bool VerifyPassword(string plainPassword, string hashedPassword)
        {
            var hashOfInput = HashPassword(plainPassword);
            return hashOfInput == hashedPassword;
        }
    }
}
