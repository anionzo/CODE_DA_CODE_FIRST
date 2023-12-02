using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace ANIONZO_API.Models
{
    public class OwnerEntity :GuidKeyEntity
    {
        public string? Name { get; set; }
        public string? Gym { get; set; }

        [ForeignKey("Category")]
        public string? CategoryID { get; set; }
        public CategoryEntity? Category { get; set; }

        public ICollection<PokemonOwnerEntity>? PokemonOwners { get; set; }

        [ForeignKey("Account")]
        public string? AccountID { get; set; }
        public AccountEntity? Account { get; set; }
    }

}
