using System.ComponentModel.DataAnnotations.Schema;

namespace ANIONZO_API.Entity
{
    public class PokemonCategoryEntity : GuidKeyEntity
    {
        [ForeignKey("Pokemon")]
        public string? PokemonId { get; set; }
        public PokemonEntity? Pokemon { get; set; }

        [ForeignKey("Category")]
        public string? CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }
    }
}
