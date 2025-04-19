using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface IFlightService : IService<Flight>
    {
        public IEnumerable<Flight> GetFlightsByDestination(string destination);
        public IEnumerable<Plane> GetFlightsByPlaneCapacity(int capacity);
    }
}
