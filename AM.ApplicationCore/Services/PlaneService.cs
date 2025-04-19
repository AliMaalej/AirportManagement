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
        public IEnumerable<Plane> getPlanesByCreationDate(int years)
        {
            var date = DateTime.Now.AddYears(years);
            return GetMany(p => p.ManufactureDate < date);
        }

        IEnumerable<Flight> IPlaneService.GetFlightsByPlaneCapacity(int capacity)
        {
            var planes = GetMany(p => p.Capacity == capacity).ToList();
            return planes.SelectMany(p => p.Flights)
                .ToList();
        }
    }
}
