using ANIONZO_API.Entity;
using ANIONZO_API.Repository.InterfaceRepository;

namespace ANIONZO_API.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly AppDataContext _context;

        public OwnerRepository( AppDataContext context) {
            _context = context;
        }
        public bool Create(OwnerEntity owner)
        {
             _context.Add(owner);
            return Save();
        }

        public bool Delete(OwnerEntity owner)
        {
            _context.Remove(owner);
            return Save();
        }

        public OwnerEntity Get(string Id)
        {
            var owner = _context.Owners.FirstOrDefault(x => x.Id == Id);
            return owner;
        }

        public ICollection<OwnerEntity> GetAll()
        {
            return _context.Owners.OrderBy(ow => ow.Id).ToList();
        }

        public ICollection<OwnerEntity> GetOwnerOfAPokemon(string pokeId)
        {
            return _context.PokemonOwners.Where(p => p.Pokemon.Id == pokeId)
                                            .Select(o => o.Owner).ToList();
        }

        public ICollection<PokemonEntity> GetPokemonByOwner(string ownerId)
        {
            return _context.PokemonOwners.Where(p => p.Owner.Id == ownerId).Select(p => p.Pokemon).ToList();
        }

        public bool OwnerExists(string Id)
        {
            var ownerExist = _context.Owners.Any(x => x.Id == Id);
            return ownerExist;
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool Update(OwnerEntity owner)
        {
           _context.Update(owner);
            return Save();
        }
    }
}
