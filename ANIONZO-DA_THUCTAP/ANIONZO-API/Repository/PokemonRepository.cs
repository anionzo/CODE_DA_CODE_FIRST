using ANIONZO_API.Entity;
using ANIONZO_API.Models;
using ANIONZO_API.Repository.InterfaceRepository;

namespace ANIONZO_API.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly AppDataContext _context;

        public PokemonRepository(AppDataContext context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool CreatePokemon(string ownerId, string categoryId, PokemonEntity pokemon)
        {
            var pokemonOwnerEntity = _context.Owners.Where(a => a.Id.Equals(ownerId)).FirstOrDefault();
            var category = _context.Categorys.Where(a => a.Id.Equals(categoryId)).FirstOrDefault();

            var pokemonOwner = new PokemonOwnerEntity()
            {
                Owner = pokemonOwnerEntity,
                Pokemon = pokemon,
            };

            _context.Add(pokemonOwner);

            var pokemonCategory = new PokemonCategoryEntity()
            {
                Category = category,
                Pokemon = pokemon,
            };

            _context.Add(pokemonCategory);

            _context.Add(pokemon);

            return Save();
        }

        public bool DeletePokemon(PokemonEntity pokemon)
        {
            _context.Remove(pokemon);
            return Save();
        }

        public ICollection<PokemonEntity> GetAll()
        {
            return _context.Pokemon.OrderBy(p => p.Id).ToList();
        }

        public PokemonEntity GetID(string id)
        {
            return _context.Pokemon.FirstOrDefault(p => p.Id.Equals(id));
        }

        public PokemonEntity GetName(string name)
        {
            return _context.Pokemon.Where(p => p.Name.Equals(name)).FirstOrDefault();

        }

        public PokemonEntity GetPokemonTrimToUpper(PokemonModel pokemonCreate)
        {
            return GetAll().Where(c => c.Name.Trim().ToUpper() == pokemonCreate.Name.TrimEnd().ToUpper())
                            .FirstOrDefault();
        }

        public decimal GetRatings(string idPokemon)
        {
            var revew = _context.Reviews.Where(p => p.Id.Equals(idPokemon));
            if(revew.Count() <= 0) return 0;
            return ((decimal)revew.Sum(r => r.Rating) / revew.Count());
        }

        public bool GetTExists(string id)
        {
            return _context.Pokemon.Any(p => p.Id.Equals(id));
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePokemon(string ownerId, string categoryId, PokemonEntity pokemon)
        {
            _context.Update(pokemon);
            return Save();
        }
    }
}
