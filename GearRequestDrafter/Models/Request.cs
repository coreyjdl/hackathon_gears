namespace GearRequestDrafter.Models
{
    // this is used for the api posts, it does not need any views. 

    public class Request
    {
        public string UserEmail { get; set; }
        public string ApplicationName { get; set; }   //ie LogRocket
        public string AppID { get; set; }
        public string Domain { get; set; } //ie GlobalPayments
        public string Environment { get; set; }
        public string RoleName { get; set; }
        public string Details { get; set; }
    }
}