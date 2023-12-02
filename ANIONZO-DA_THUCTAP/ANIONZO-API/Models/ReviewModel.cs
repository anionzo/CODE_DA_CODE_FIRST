namespace ANIONZO_API.Models
{
    public class ReviewModel
    {
        public string Id { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public int? Rating { get; set; }
        public string? ReviewerId { get; set; }
        public string? PokemonId { get; set; }
    }
}
