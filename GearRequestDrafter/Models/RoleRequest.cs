using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GearRequestDrafter.Models
{
    public class RoleRequest
    {
        public string RoleName { get; set; }
        public IEnumerable<GearsRequest> GearsRequests { get; set; }    
    }
}