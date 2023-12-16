using ANIONZO_API.Entity;
using ANIONZO_API.Repository.InterfaceRepository;

namespace ANIONZO_API.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDataContext _context;

        public CountryRepository(AppDataContext context)
        {
            _context = context;
        }
        public bool Create(CountryEntity country)
        {
            _context.Add(country);
            return Save();
        }

        public bool Delete(CountryEntity country)
        {
            _context.Remove(country);
            return Save();
        }

        public bool Exists(string id)
        {
            return _context.Countries.Any(ctry => ctry.Id == id);         }

        public CountryEntity Get(string id)
        {
            var country = _context.Countries.FirstOrDefault(ctry => ctry.Id == id);
            if (country == null)
            {
                country = new CountryEntity();
            }
            return country;

        }

        public ICollection<CountryEntity> GetAll()
        {
            var countrys = _context.Countries.ToList();
            return countrys;
        }

        public CountryEntity GetCountryByOwner(string ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<OwnerEntity> GetOwnersFromACountry(string countryId)
        {
            return _context.Owners.Where(c => c.Country.Id == countryId).ToList();
        }

        public bool Save()
        {
           var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool Update(CountryEntity country)
        {
            _context.Update(country);
            return Save();
        }
    }
}
