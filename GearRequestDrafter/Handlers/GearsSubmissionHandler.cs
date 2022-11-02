using GearRequestDrafter.Models;
using GearRequestDrafter.Repositories;
using System.Collections.Generic;


namespace GearRequestDrafter.Handlers
{
    public class GearsSubmissionHandler : IGearsSubmissionHandler
    {
        public IGearsRepository gearsRepository;
        
        public GearsSubmissionHandler()
        {
            gearsRepository = new GearsRepository();
        }

        public void SubmitUserRequests(User user)
        {
            var requests = mapUser(user);
            foreach (var request in requests)
            {
                gearsRepository.SendRequest(request);
            }
        }

        private List<Request> mapUser(User user)
        {
            var request = new List<Request>();

            foreach(var gearsRequest in user.GearsRequests)
            {
                request.Add(new Request()
                {
                    UserEmail = user.Email,
                    ApplicationName = gearsRequest.ApplicationName,
                    AppID = gearsRequest.AppID,
                    Domain = gearsRequest.Domain,
                    Environment = gearsRequest.Environment,
                    RoleName = gearsRequest.RoleName,
                    Details = gearsRequest.Details
                });

            }

            return request;
        }
    }
}