using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace ANIONZO_API.Entity
{
    public class OwnerEntity :GuidKeyEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gym { get; set; }

        [ForeignKey("Country")]
        public string? CategoryID { get; set; }
        public CountryEntity? Country { get; set; }

        public ICollection<PokemonOwnerEntity>? PokemonOwners { get; set; }

        //[ForeignKey("Account")]
        //public string? AccountID { get; set; }
        //public AccountEntity? Account { get; set; }
    }

}
