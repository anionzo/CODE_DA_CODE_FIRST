namespace ANIONZO_API.Entity
{
    public class PokemonEntity :GuidKeyEntity
    {
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<ReviewEntity>? Reviews { get; set; }
        public ICollection<PokemonCategoryEntity>? PokemonCategories { get; set; }
        public ICollection<PokemonOwnerEntity>? PokemonOwners { get; set; }
    }
}
