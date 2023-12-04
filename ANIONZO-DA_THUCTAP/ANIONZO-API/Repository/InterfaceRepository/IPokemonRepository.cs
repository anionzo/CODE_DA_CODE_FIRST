using ANIONZO_API.Entity;
using ANIONZO_API.Models;

namespace ANIONZO_API.Repository.InterfaceRepository
{
    public interface IPokemonRepository
    {
        ICollection<PokemonEntity> GetAll();
        PokemonEntity GetID(string id);
        PokemonEntity GetName(string name);
        PokemonEntity GetPokemonTrimToUpper(PokemonModel pokemonCreate);
        decimal GetRatings(string idPokemon);
        bool GetTExists(string id);
        bool CreatePokemon(string ownerId, string categoryId, PokemonEntity pokemon);
        bool UpdatePokemon(string ownerId, string categoryId, PokemonEntity pokemon);
        bool DeletePokemon(PokemonEntity pokemon);
        bool Save();
    }
}
