using static ANIONZO_API.Constants.WebApiEndpoint;
using System.Diagnostics.Metrics;
using ANIONZO_API.Entity;
using AutoMapper;
using ANIONZO_API.Models;

namespace ANIONZO_API.Constants
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AccountModel, AccountEntity>().ReverseMap();

            CreateMap<CategoryModel, CategoryEntity>().ReverseMap();

            CreateMap<CountryModel, CountryEntity>().ReverseMap();

            CreateMap<OwnerModel, OwnerEntity>().ReverseMap();

            CreateMap<PokemonModel, PokemonEntity>().ReverseMap();

            CreateMap<PokemonCategoryModel, PokemonCategoryEntity>().ReverseMap();

            CreateMap<PokemonOwnerModel, PokemonOwnerEntity>().ReverseMap();

            CreateMap<ReviewModel, ReviewEntity>().ReverseMap();

            CreateMap<ReviewerModel, ReviewerEntity>().ReverseMap();
        }
    }
}
