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
    }
}
