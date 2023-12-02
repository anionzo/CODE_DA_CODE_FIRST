namespace ANIONZO_API.Models
{
    public class CategoryEntity :GuidKeyEntity
    {
        public string? Name { get; set; }
        public ICollection<PokemonCategoryEntity>? PokemonCategories { get; set; }
    }
}
