using System.ComponentModel.DataAnnotations.Schema;

namespace ANIONZO_API.Models
{
    public class ModelsEntity
    {
        public class AccountEntity : GuidKeyEntity
        {
            public string? Username { get; set; }
            public string? PasswordHash { get; set; }
        }
        public class CategoryEntity : GuidKeyEntity
        {
            public string? Name { get; set; }
            public ICollection<PokemonCategoryEntity>? PokemonCategories { get; set; }
        }
        public class CountryEntity : GuidKeyEntity
        {
            public string? Name { get; set; }
            public ICollection<OwnerEntity>? Owners { get; set; }
        }
        public class OwnerEntity : GuidKeyEntity
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
        public class PokemonCategoryEntity : GuidKeyEntity
        {
            public string? PokemonId { get; set; }
            [ForeignKey("Pokemon")]
            public PokemonEntity? Pokemon { get; set; }

            [ForeignKey("Category")]
            public string? CategoryId { get; set; }
            public CategoryEntity? Category { get; set; }
        }
        public class PokemonEntity : GuidKeyEntity
        {
            public string? Name { get; set; }
            public DateTime BirthDate { get; set; }
            public ICollection<ReviewEntity>? Reviews { get; set; }
            public ICollection<PokemonCategoryEntity>? PokemonCategories { get; set; }
            public ICollection<PokemonOwnerEntity>? PokemonOwners { get; set; }
        }
        public class PokemonOwnerEntity : GuidKeyEntity
        {
            [ForeignKey("Pokemon")]
            public string? PokemonId { get; set; }
            public PokemonEntity? Pokemon { get; set; }

            [ForeignKey("Owner")]
            public string? OwnerId { get; set; }
            public OwnerEntity? Owner { get; set; }
        }
        public class ReviewEntity : GuidKeyEntity
        {
            public string? Title { get; set; }
            public string? Content { get; set; }
            [ForeignKey("Reviewer")]
            public string? ReviewerID;
            public ReviewerEntity? Reviewer { get; set; }
            [ForeignKey("Pokemon")]
            public string? PokemonID;
            public PokemonEntity? Pokemon { get; set; }
        }
        public class ReviewerEntity : GuidKeyEntity
        {
            public string? LastName { get; set; }
            public string? FirstName { get; set; }
            public ICollection<ReviewEntity>? Reviews { get; set; }
        }
    }
}
