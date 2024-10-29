using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    internal class ParkingLot
    {
        public int ParkingSpaces { get; set; }
        List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

        public ParkingLot(int parkingSpaces, List<Vehicle> vehicles)
        {
            ParkingSpaces = parkingSpaces;
        }
        public void PrintParkedVehicles()
        {

        }
    }
}
