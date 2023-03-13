using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLACKY.Entities.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string EmailID { get; set; }

        public string MobileNumber { get; set; }

        public bool IsActive { get; set; }

    }
}
