using System.ComponentModel.DataAnnotations.Schema;

namespace ANIONZO_API.Models
{
    public class ReviewEntity : GuidKeyEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        [ForeignKey("Reviewer")]
        public string ReviewerID;
        public ReviewerEntity Reviewer { get; set; }
        [ForeignKey("Pokemon")]
        public string PokemonID;
        public PokemonEntity Pokemon { get; set; }
    }
}
