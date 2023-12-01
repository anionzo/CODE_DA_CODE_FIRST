namespace ANIONZO_API.Models
{
    public class AccountEntity : GuidKeyEntity
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}
