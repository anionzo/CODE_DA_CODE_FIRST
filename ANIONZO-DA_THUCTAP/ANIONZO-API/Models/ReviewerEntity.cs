namespace ANIONZO_API.Models
{
    public class ReviewerEntity : GuidKeyEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public ICollection<ReviewEntity> Reviews { get; set; }
    }
}
