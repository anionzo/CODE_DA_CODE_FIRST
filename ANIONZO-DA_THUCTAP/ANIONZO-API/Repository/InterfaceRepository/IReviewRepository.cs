using ANIONZO_API.Entity;

namespace ANIONZO_API.Repository.InterfaceRepository
{
    public interface IReviewRepository
    {
        ICollection<ReviewEntity> GetALL();
        ReviewEntity Get(string reviewId);
        ICollection<ReviewEntity> GetReviewsOfAPokemon(string pokeId);
        bool Exists(string reviewId);
        bool Create(ReviewEntity review);
        bool Update(ReviewEntity review);
        bool Delete(ReviewEntity review);
        bool DeleteList(List<ReviewEntity> reviews);
        bool Save();
    }
}
