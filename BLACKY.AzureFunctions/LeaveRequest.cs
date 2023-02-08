using Newtonsoft.Json;
using System;

namespace BLACKY.AzureFunctions
{
    public class LeaveRequest
    {
        [JsonProperty(PropertyName = "employeeId")]
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
