using ANIONZO_API.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace ANIONZO_API
{
    public class AppDataContext : DbContext
    {
        // migrations 
        // dotnet ef migrations add Update1 -v --context AppDataContext
        // dotnet ef database update -v --context AppDataContext
        // dotnet ef migrations remove
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }
        public AppDataContext() : base() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(local); Initial Catalog=Anionzo; User Id=sa; Password=123; Trusted_Connection=True; Trust Server Certificate=True; Integrated Security=false;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<CategoryEntity> Categorys { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<OwnerEntity> Owners { get; set; }
        public DbSet<PokemonEntity> Pokemons { get; set; }
        public DbSet<PokemonOwnerEntity> PokemonOwners { get; set; }
        public DbSet<PokemonCategoryEntity> PokemonCategories { get; set; }
        public DbSet<ReviewerEntity> Reviewers { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
