namespace BLACKY.WebAPI.Models
{
    public class UserEntity : AuditableEntity
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailID { get; set; }
        public string MobileNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
