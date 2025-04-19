using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class PlaneService : Service<Plane>, IPlaneService
    {
        public PlaneService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public IEnumerable<Plane> getPlanesByCreationDate()
        {
            var date = DateTime.Now.AddYears(-3);
            return GetMany(p => p.ManufactureDate < date);
        }

        public IEnumerable<Flight> GetFlightsByPlaneCapacity(int capacity)
        {
            return GetMany(p => p.Capacity == capacity)
                .SelectMany(p => p.Flights) 
                .ToList(); 
        }
    }
}
