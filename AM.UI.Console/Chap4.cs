using AM.ApplicationCore;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.UI.Console
{
    internal class Chap4
    {
        public static void Test1()
        {
            using(var unitOfWork = new UnitOfWork())
            {
                unitOfWork.Repository<Plane>().Add(InMemorySource.Boeing1);
                unitOfWork.Repository<Plane>().Add(InMemorySource.Boeing2);
                unitOfWork.Commit();
                unitOfWork.Repository<Plane>().Add(InMemorySource.Airbus);
            }
        }

        public static void Test2()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                IFlightService flightService = new FlightService(unitOfWork);
                var flights = flightService.GetFlightsByDestination("Paris");
                flights.ToList().ShowList("=== Flights list ===", System.Console.WriteLine);

                IPlaneService planeService = new PlaneService(unitOfWork);
                var planes = planeService.getPlanesByCreationDate();
                planes.ToList().ShowList("=== Planes list ===", System.Console.WriteLine);

                planeService.GetFlightsByPlaneCapacity(int capacity);
            }
        }
    }
}
