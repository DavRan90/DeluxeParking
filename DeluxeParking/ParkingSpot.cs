using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    internal class ParkingSpot
    {
        public bool Occupied { get; set; }
        public List<Vehicle> VehiclesParked { get; set; }

        public int ParkingSpotNumber { get; set; }

        public ParkingSpot(int parkingSpotNumber, Vehicle vehicle)
        {
            ParkingSpotNumber = parkingSpotNumber;
            if (vehicle is Car || vehicle is Bus)
            {
                Occupied = true;
            }
        }

    }
}
