using GearRequestDrafter.Models;

namespace GearRequestDrafter.Handlers
{
    public interface IGearsSubmissionHandler
    {
        void SubmitUserRequestsAsync(User user);
    }
}
