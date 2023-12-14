namespace ANIONZO_API.Entity
{
    public class ReviewerEntity : GuidKeyEntity
    {
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public ICollection<ReviewEntity>? Reviews { get; set; }
    }
}
