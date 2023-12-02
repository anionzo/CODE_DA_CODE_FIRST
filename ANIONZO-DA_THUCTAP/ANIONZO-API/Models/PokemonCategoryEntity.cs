using System.ComponentModel.DataAnnotations.Schema;

namespace ANIONZO_API.Models
{
    public class PokemonCategoryEntity : GuidKeyEntity
    {
        public string? PokemonId { get; set; }
        [ForeignKey("Pokemon")]
        public PokemonEntity? Pokemon { get; set; }

        [ForeignKey("Category")]
        public string? CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }
    }
}
