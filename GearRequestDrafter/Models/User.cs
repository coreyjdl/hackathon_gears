using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GearRequestDrafter.Models
{
    public class User : RoleRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserID { get; set; }
    }
}
