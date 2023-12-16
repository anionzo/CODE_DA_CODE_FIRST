using ANIONZO_API.Entity;
using ANIONZO_API.Repository.InterfaceRepository;

namespace ANIONZO_API.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly AppDataContext _context;

        public ReviewerRepository(AppDataContext context) {
            _context = context;
        }
        public bool Create(ReviewerEntity reviewer)
        {
            _context.Add(reviewer);
            return Save();
        }

        public bool Delete(ReviewerEntity reviewer)
        {
            _context.Remove(reviewer);
            return Save();
        }

        public bool Exists(string Id)
        {
            return _context.Reviewers.Any(x => x.Id == Id);
        }

        public ReviewerEntity Get(string Id)
        {
            return _context.Reviewers.FirstOrDefault(re => re.Id == Id) ?? null;
        }

        public ICollection<ReviewerEntity> GetAll()
        {
            return _context.Reviewers.ToList();
        }

        public ICollection<ReviewEntity> GetReviewsByReviewer(string reviewerId)
        {
            return _context.Reviews.Where(r => r.Reviewer.Id == reviewerId).ToList();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool Update(ReviewerEntity reviewer)
        {
            _context.Update(reviewer);
            return true;
        }
    }
}
