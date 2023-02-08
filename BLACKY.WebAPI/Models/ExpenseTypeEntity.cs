namespace BLACKY.WebAPI.Models
{
    public class ExpenseTypeEntity : AuditableEntity
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
