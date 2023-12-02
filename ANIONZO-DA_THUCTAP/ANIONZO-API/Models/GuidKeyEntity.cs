using ANIONZO_API.Utils;
using System.ComponentModel.DataAnnotations;

namespace ANIONZO_API.Models
{
    public class GuidKeyEntity
    {
        protected GuidKeyEntity()
        {
            Id = Guid.NewGuid().ToString();
            CreatedTime = LastUpdatedTime = ApiHelper.SystemTimeNow;
        }

        [Key]
        public string Id { get; set; }
        public string? CreatedBy { get; set; }
        public string? LastUpdatedBy { get; set; }
        public string? DeletedBy { get; set; }

        public DateTimeOffset? CreatedTime { get; set; }

        public DateTimeOffset? LastUpdatedTime { get; set; }

        public DateTimeOffset? DeletedTime { get; set; }
        public string? Code { get; set; }
    }

}
