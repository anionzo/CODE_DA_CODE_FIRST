using ANIONZO_API.Entity;

namespace ANIONZO_API.Repository.InterfaceRepository
{
    public interface IReviewerRepository
    {
        ICollection<ReviewerEntity> GetAll();
        ReviewerEntity Get(string Id);
        ICollection<ReviewEntity> GetReviewsByReviewer(string Id);
        bool Exists(string Id);
        bool Create(ReviewerEntity reviewer);
        bool Update(ReviewerEntity reviewer);
        bool Delete(ReviewerEntity reviewer);
        bool Save();
    }
}
