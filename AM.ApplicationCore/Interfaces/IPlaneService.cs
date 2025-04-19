using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface IPlaneService : IService<Plane>
    {
        public IEnumerable<Plane> getPlanesByCreationDate(int years);
        public IEnumerable<Flight> GetFlightsByPlaneCapacity(int capacity);
    }
}
