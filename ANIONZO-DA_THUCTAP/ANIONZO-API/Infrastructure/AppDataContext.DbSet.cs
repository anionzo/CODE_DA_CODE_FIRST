using ANIONZO_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ANIONZO_API.Infrastructure
{
    public sealed partial class AppDataContext
    {
        public DbSet<AccountEntity> Accounts { get; set; }

        public DbSet<CategoryEntity> Categorys { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<OwnerEntity> Owners { get; set; }
        public DbSet<PokemonEntity> Pokemons { get; set; }
        public DbSet<PokemonOwnerEntity> PokemonOwners { get; set; }
        public DbSet<PokemonCategoryEntity> PokemonCategories { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<ReviewerEntity> Reviewers { get; set; }
    }
}
