using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GearsMock.Models
{
    public class GearsRequest
    {
        public string ApplicationName { get; set; }   //ie LogRocket
        public string AppID { get; set; }
        public string Domain { get; set; } //ie GlobalPayments
        public string Environment { get; set; }
        public string RoleName { get; set; }
        public string Details { get; set; }
    }
}