using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class FlightService : Service<Flight>, IFlightService
    {
        public FlightService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        IEnumerable<Flight> IFlightService.GetFlightsByDestination(string destination)
        {
            return GetMany(d => d.Destination == destination);
        }
    }
}
