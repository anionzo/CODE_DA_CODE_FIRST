namespace ANIONZO_API.Models
{
    public class AccountModel
    {
        public string? Username { get; set; }
        public string? PasswordHash { get; set; } = null;
    }
}
