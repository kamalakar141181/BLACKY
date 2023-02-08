using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BLACKY.WebAPI.Models
{
    public class AuditableEntity : IAuditableEntity
    {

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        //[Timestamp]
        //[JsonConverter(typeof(RowVersionJsonConverter))]
        //public byte[] RowVersion { get; set; }
    }
}
