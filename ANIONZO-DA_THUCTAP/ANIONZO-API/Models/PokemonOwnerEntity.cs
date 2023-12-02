using System.ComponentModel.DataAnnotations.Schema;

namespace ANIONZO_API.Models
{
    public class PokemonOwnerEntity : GuidKeyEntity
    {
        [ForeignKey("Pokemon")]
        public string? PokemonId { get; set; }
        public PokemonEntity? Pokemon { get; set; }

        [ForeignKey("Owner")]
        public string? OwnerId { get; set; }
        public OwnerEntity? Owner { get; set; }
    }
}
