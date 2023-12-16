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
        }
    }
}
