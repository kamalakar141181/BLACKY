namespace BLACKY.WebAPI.Models
{
    public interface IAuditableEntity
    {
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        //public byte[] RowVersion { get; set; }
    }
}
