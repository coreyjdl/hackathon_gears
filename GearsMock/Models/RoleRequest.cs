using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GearsMock.Models
{
    public class RoleRequest
    {
        public User user { get; set; }
        public IEnumerable<GearsRequest> GearsRequests { get; set; }    
    }
}