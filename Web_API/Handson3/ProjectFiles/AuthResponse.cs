namespace ProductAPI.Models
{
    public class AuthResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public string token { get; set; }
        public User user { get; set; }
    }
}
