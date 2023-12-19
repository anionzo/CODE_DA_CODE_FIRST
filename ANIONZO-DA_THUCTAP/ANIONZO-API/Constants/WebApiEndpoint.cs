namespace ANIONZO_API.Constants
{
    public static class WebApiEndpoint
    {
        public const string AreaName = "api";
        public static class Pokemon
        {
            private const string BaseEndpoint = "~/" + AreaName + "/pokemon";
            public const string GetPokemon = BaseEndpoint + "/get-single" + "/{Id}";
            public const string GetAllPokemon = BaseEndpoint + "/get-all";
            public const string GetRatings = BaseEndpoint + "/get-rating" + "/{Id}";
            public const string AddPokemon = BaseEndpoint + "/add";
            public const string UpdatePokemon = BaseEndpoint + "/update" + "/{Id}";
            public const string DeletePokemon = BaseEndpoint + "/delete" + "/{Id}";
        }
        public static class Category
        {
            private const string BaseEndpoint = "~/" + AreaName + "/category";
            public const string GetCategory = BaseEndpoint + "/get-single" + "/{Id}";
            public const string GetAllCategory = BaseEndpoint + "/get-all";
            public const string AddCategory = BaseEndpoint + "/add";
            public const string UpdateCategory = BaseEndpoint + "/update" + "/{Id}";
            public const string DeleteCategory = BaseEndpoint + "/delete" + "/{Id}";
        }
        public static class Owner
        {
            private const string BaseEndpoint = "~/" + AreaName + "/owner";
            public const string GetOwner = BaseEndpoint + "/get-single" + "/{Id}";
            public const string GetAllOwner = BaseEndpoint + "/get-all";
            public const string AddOwner = BaseEndpoint + "/add";
            public const string UpdateOwner = BaseEndpoint + "/update" + "/{Id}";
            public const string DeleteOwner = BaseEndpoint + "/delete" + "/{Id}";
            public const string GetPokemonByOwner = BaseEndpoint + "/{ownerId}/pokemon";
        }

        public static class Country
        {
            private const string BaseEndpoint = "~/" + AreaName + "/country";
            public const string GetCountry = BaseEndpoint + "/get-single" + "/{countryId}";
            public const string GetAllCountry = BaseEndpoint + "/get-all";
            public const string AddCountry = BaseEndpoint + "/add";
            public const string UpdateCountry = BaseEndpoint + "/update" + "/{countryId}";
            public const string DeleteCountry = BaseEndpoint + "/delete" + "/{countryId}";
            public const string GetCountryOfAnOwner = BaseEndpoint + "/owners" + "/{ownerId}";
        }

        public static class Review
        {
            private const string BaseEndpoint = "~/" + AreaName + "/review";
            public const string GetReview = BaseEndpoint + "/get-single" + "/{reviewId}";
            public const string GetAllReview = BaseEndpoint + "/get-all";
            public const string AddReview = BaseEndpoint + "/add";
            public const string UpdateReview = BaseEndpoint + "/update" + "/{reviewId}";
            public const string DeleteReview = BaseEndpoint + "/delete" + "/{reviewId}";
            public const string DeleteReviewsByReviewer = BaseEndpoint + "/DeleteReviewsByReviewer" + "/{reviewerId}";
            public const string GetReviewsForAPokemon = BaseEndpoint + "pokemon " + "/{pokeId}";
            public const string GetPokemon = BaseEndpoint + "/get-single-pokemon" + "/{reviewId}";


        }
        public static class Reviewer
        {
            private const string BaseEndpoint = "~/" + AreaName + "/reviewer";
            public const string GetReviewer = BaseEndpoint + "/get-single" + "/{reviewerId}";
            public const string GetAllReviewer = BaseEndpoint + "/get-all";
            public const string AddReviewer = BaseEndpoint + "/add";
            public const string UpdateReviewer = BaseEndpoint + "/update" + "/{reviewerId}";
            public const string DeleteReviewer = BaseEndpoint + "/delete" + "/{reviewerId}";
            public const string GetReviewsByAReviewer = BaseEndpoint + "{reviewerId}"+" /reviews";
        }

    }
}
