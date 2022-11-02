using GearRequestDrafter.Models;

namespace GearRequestDrafter.Repositories
{
    public interface IDiskRepository
    {
        void Write(ProfileLibrary pLibrary);

        ProfileLibrary Read();

    }
}
