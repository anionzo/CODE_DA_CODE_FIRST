using ANIONZO_API.Entity;
using ANIONZO_API.Repository.InterfaceRepository;

namespace ANIONZO_API.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDataContext _context;

        public CategoryRepository(AppDataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool Create(CategoryEntity category)
        {
            _context.Add(category);
            return Save();
        }

        public bool Delete(CategoryEntity category)
        {
            _context.Remove(category);
            return Save();
            
        }

        public CategoryEntity Get(string id)
        {
            var category =   _context.Categorys.FirstOrDefault(c => c.Id == id);
            return category;
        }

        public ICollection<CategoryEntity> GetAll()
        {
            var categorys = _context.Categorys.Where(cate => cate != null).ToList();
            return categorys;
        }

        public ICollection<PokemonEntity> GetPokemonByCategory(string categoryId)
        {
            return _context.PokemonCategories.Where(e => e.Id == categoryId).Select(s => s.Pokemon).ToList();
        }

        public bool GetTExists(string id)
        {
            return _context.Categorys.Any(p => p.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(CategoryEntity category)
        {
            var update = _context.Update(category);
            return Save();
        }
    }
}
