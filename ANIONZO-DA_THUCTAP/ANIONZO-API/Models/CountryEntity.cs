namespace ANIONZO_API.Models
{
    public class CountryEntity: GuidKeyEntity
    {
        public string Name { get; set; }
        public ICollection<OwnerEntity> Owners { get; set; }
    }
}
