using ANIONZO_API.Entity;
using System.Diagnostics.Metrics;

namespace ANIONZO_API
{
    public class Seed
    {
        private readonly AppDataContext dataContext;
        public Seed(AppDataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.PokemonOwners.Any())
            {
                var pokemonOwners = new List<PokemonOwnerEntity>()
                {
                    new PokemonOwnerEntity()
                    {
                        Pokemon = new PokemonEntity()
                        {
                            Name = "Pikachu",
                            BirthDate = new DateTime(1903,1,1),
                            PokemonCategories = new List<PokemonCategoryEntity>()
                            {
                                new PokemonCategoryEntity { Category = new CategoryEntity() { Name = "Electric"}}
                            },
                            Reviews = new List<ReviewEntity>()
                            {
                                new ReviewEntity { Title="Pikachu",Text = "Pickahu is the best pokemon, because it is electric", Rating = 5,
                                Reviewer = new ReviewerEntity(){ FirstName = "Teddy", LastName = "Smith" } },
                                new ReviewEntity { Title="Pikachu", Text = "Pickachu is the best a killing rocks", Rating = 5,
                                Reviewer = new ReviewerEntity(){ FirstName = "Taylor", LastName = "Jones" } },
                                new ReviewEntity { Title="Pikachu",Text = "Pickchu, pickachu, pikachu", Rating = 1,
                                Reviewer = new ReviewerEntity(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Owner = new OwnerEntity()
                        {
                            FirstName = "Jack",
                            LastName = "London",
                            Gym = "Brocks Gym",
                            Country = new CountryEntity()
                            {
                                Name = "Kanto"
                            }
                        }
                    },
                    new PokemonOwnerEntity()
                    {
                        Pokemon = new PokemonEntity()
                        {
                            Name = "Squirtle",
                            BirthDate = new DateTime(1903,1,1),
                            PokemonCategories = new List<PokemonCategoryEntity>()
                            {
                                new PokemonCategoryEntity { Category = new CategoryEntity() { Name = "Water"}}
                            },
                            Reviews = new List<ReviewEntity>()
                            {
                                new ReviewEntity { Title= "Squirtle", Text = "squirtle is the best pokemon, because it is electric", Rating = 5,
                                Reviewer = new ReviewerEntity(){ FirstName = "Teddy", LastName = "Smith" } },
                                new ReviewEntity { Title= "Squirtle",Text = "Squirtle is the best a killing rocks", Rating = 5,
                                Reviewer = new ReviewerEntity(){ FirstName = "Taylor", LastName = "Jones" } },
                                new ReviewEntity { Title= "Squirtle", Text = "squirtle, squirtle, squirtle", Rating = 1,
                                Reviewer = new ReviewerEntity(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Owner = new OwnerEntity()
                        {
                            FirstName = "Harry",
                            LastName = "Potter",
                            Gym = "Mistys Gym",
                            Country = new CountryEntity()
                            {
                                Name = "Saffron City"
                            }
                        }
                    },
                                    new PokemonOwnerEntity()
                    {
                        Pokemon = new PokemonEntity()
                        {
                            Name = "Venasuar",
                            BirthDate = new DateTime(1903,1,1),
                            PokemonCategories = new List<PokemonCategoryEntity>()
                            {
                                new PokemonCategoryEntity { Category = new CategoryEntity() { Name = "Leaf"}}
                            },
                            Reviews = new List<ReviewEntity>()
                            {
                                new ReviewEntity { Title="Veasaur",Text = "Venasuar is the best pokemon, because it is electric", Rating = 5,
                                Reviewer = new ReviewerEntity(){ FirstName = "Teddy", LastName = "Smith" } },
                                new ReviewEntity { Title="Veasaur",Text = "Venasuar is the best a killing rocks", Rating = 5,
                                Reviewer = new ReviewerEntity(){ FirstName = "Taylor", LastName = "Jones" } },
                                new ReviewEntity { Title="Veasaur",Text = "Venasuar, Venasuar, Venasuar", Rating = 1,
                                Reviewer = new ReviewerEntity(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Owner = new OwnerEntity()
                        {
                            FirstName = "Ash",
                            LastName = "Ketchum",
                            Gym = "Ashs Gym",
                            Country = new CountryEntity()
                            {
                                Name = "Millet Town"
                            }
                        }
                    }
                };
                dataContext.PokemonOwners.AddRange(pokemonOwners);
                dataContext.SaveChanges();
            }
        }
    }
}
