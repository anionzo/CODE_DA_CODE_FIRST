using ANIONZO_API.Entity;
using ANIONZO_API.Repository.InterfaceRepository;

namespace ANIONZO_API.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDataContext _context;

        public ReviewRepository(AppDataContext context)
        {
            _context = context;
        }
        public bool Create(ReviewEntity review)
        {
            _context.Add(review);
            return Save();
        }

        public bool Delete(ReviewEntity review)
        {
            _context.Remove(review);
            return Save();
        }

        public bool DeleteList(List<ReviewEntity> reviews)
        {
            _context.Remove(reviews);
            return Save();
        }

        public bool Exists(string reviewId)
        {
            return _context.Reviews.Any(x => x.Id == reviewId);
        }

        public ReviewEntity Get(string reviewId)
        {
            return _context.Reviews.FirstOrDefault(x => x.Id.Equals(reviewId));
        }

        public ICollection<ReviewEntity> GetALL()
        {
            return _context.Reviews.ToList();
        }

        public ICollection<ReviewEntity> GetReviewsOfAPokemon(string pokeId)
        {
            var reviers = _context.Reviews.Where(x => x.Pokemon.Id == pokeId).ToList();
            return reviers;
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ;
        }

        public bool Update(ReviewEntity review)
        {
            _context.Update(review);
            return Save();
        }
    }
}
