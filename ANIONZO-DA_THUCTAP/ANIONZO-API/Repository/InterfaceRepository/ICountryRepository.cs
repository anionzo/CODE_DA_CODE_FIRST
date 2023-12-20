using static ANIONZO_API.Constants.WebApiEndpoint;
using System.Diagnostics.Metrics;
using ANIONZO_API.Entity;

namespace ANIONZO_API.Repository.InterfaceRepository
{
    public interface ICountryRepository
    {
        ICollection<CountryEntity> GetAll();
        CountryEntity Get(string id);
        CountryEntity GetCountryByOwner(string ownerId);
        ICollection<OwnerEntity> GetOwnersFromACountry(string countryId);
        bool Exists(string id);
        bool Create(CountryEntity country);
        bool Update(CountryEntity country);
        bool Delete(CountryEntity country);
        bool Save();
    }
}

