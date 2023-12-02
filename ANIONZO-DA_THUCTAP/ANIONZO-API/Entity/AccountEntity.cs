namespace ANIONZO_API.Entity
{
    public class AccountEntity : GuidKeyEntity
    {
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
    }
}
