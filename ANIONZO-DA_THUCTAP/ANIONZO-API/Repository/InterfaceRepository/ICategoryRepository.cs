using ANIONZO_API.Entity;
using ANIONZO_API.Models;
using static ANIONZO_API.Constants.WebApiEndpoint;

namespace ANIONZO_API.Repository.InterfaceRepository
{
    public interface ICategoryRepository
    {
        ICollection<CategoryEntity> GetAll();
        CategoryEntity Get(string id);
        ICollection<PokemonEntity> GetPokemonByCategory(string categoryId);
        bool GetTExists(string id);
        bool Create( CategoryEntity category);
        bool Update(CategoryEntity category);
        bool Delete(CategoryEntity category);
        bool Save();
    }
}
