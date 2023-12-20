using ANIONZO_API.Entity;
using ANIONZO_API.Models;
using ANIONZO_API.Repository.InterfaceRepository;
using ANIONZO_API.Utils;

namespace ANIONZO_API.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly AppDataContext? _context = null;
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
            var po = GetID(pokemon.Id);
            po.DeletedTime = ApiHelper.SystemTimeNow;
            _context.Update(po);
            //_context.Remove(pokemon);
            return Save();
        }

        public ICollection<PokemonEntity> GetAll()
        {
            return _context.Pokemon.OrderBy(p => p.Id).ToList();
        }

        public PokemonEntity GetID(string Id)
        {
            return _context.Pokemon.FirstOrDefault(p => p.Id.Equals(Id));
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
            var review = _context.Reviews.Where(p => p.Pokemon.Id == idPokemon).ToList();

            if(review.Sum(r => r.Rating) != 0)
                return ((decimal)review.Sum(r => r.Rating) / review.Count());
            return 0;
        }

        public bool GetTExists(string Id)
        {
            return _context.Pokemon.Any(p => string.Equals(p.Id, Id));
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        public bool UpdatePokemon(string ownerId, string categoryId, PokemonEntity pokemon)
        {

            if (ownerId == null)
                return false;
            else
            {
                var owner = _context.Owners.Where(a => a.Id.Equals(ownerId)).FirstOrDefault();

                var pokemonOwner = _context.PokemonOwners.Where(a => a.PokemonId == pokemon.Id).FirstOrDefault();
                pokemonOwner.OwnerId = owner.Id;
                _context.Update(pokemonOwner);
            }
            if (categoryId == null)
                return false;
            else
            {
                var category = _context.Categorys.Where(a => a.Id.Equals(categoryId)).FirstOrDefault();
                var pokemonCategory = _context.PokemonCategories.Where(a => a.PokemonId == pokemon.Id).FirstOrDefault();
                pokemonCategory.CategoryId = category.Id;

                _context.Update(pokemonCategory);
            }
            _context.Update(pokemon);
            return Save();
        }
    }
}
