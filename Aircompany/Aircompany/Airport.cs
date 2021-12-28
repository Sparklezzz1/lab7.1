using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        private readonly IEnumerable<Plane> Planes;

        public Airport(IEnumerable<Plane> planes)
        {
            Planes = planes;
        }

        public IEnumerable<T> GetPlanes<T>() where T : Plane
        {
            return Planes.Where(plane => plane.GetType() == typeof(T)).Cast<T>();
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            return GetPlanes<PassengerPlane>().OrderByDescending(plane => plane.GetPassengersCapacity()).First();
        }

        public IEnumerable<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return GetPlanes<MilitaryPlane>().Where(plane => plane.GetPlaneType() == MilitaryType.TRANSPORT);
        }

        public Airport SortByMaxDistance()
        {
            return new Airport(Planes.OrderBy(w => w.GetMaxFlightDistance()));
        }

        public Airport SortByMaxSpeed()
        {
            return new Airport(Planes.OrderBy(w => w.GetMaxSpeed()));
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(Planes.OrderBy(w => w.GetMaxLoadCapacity()));
        }

        public override string ToString()
        {
            return "Airport{" +
                    "planes=" + string.Join(", ", Planes.Select(x => x.GetModel())) +
                    '}';
        }
    }
}
