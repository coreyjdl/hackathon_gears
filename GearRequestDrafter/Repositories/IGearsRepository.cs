using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GearRequestDrafter.Models;

namespace GearRequestDrafter.Repositories
{
    public interface IGearsRepository
    {
        void SendRequest(Request request);
    }
}
