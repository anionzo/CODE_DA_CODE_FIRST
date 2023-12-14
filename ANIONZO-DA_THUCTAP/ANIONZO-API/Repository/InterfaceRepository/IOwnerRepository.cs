using ANIONZO_API.Entity;
using static ANIONZO_API.Constants.WebApiEndpoint;

namespace ANIONZO_API.Repository.InterfaceRepository
{
    public interface IOwnerRepository
    {
        ICollection<OwnerEntity> GetAll();
        OwnerEntity Get(string Id);
        ICollection<OwnerEntity> GetOwnerOfAPokemon(string pokeId);
        ICollection<PokemonEntity> GetPokemonByOwner(string ownerId);
        bool OwnerExists(string Id);
        bool Create(OwnerEntity owner);
        bool Update(OwnerEntity owner);
        bool Delete(OwnerEntity owner);
        bool Save();
    }
}
