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
        //Vehicle[] parkingSpaces = new Vehicle[16];
        
        List<ParkingSpot> ParkingSpots { get; set; } = new List<ParkingSpot>();

        public ParkingLot(int parkingSpaces, List<Vehicle> vehicles)
        {
            ParkingSpaces = parkingSpaces;
        }
        public void PrintParkedVehicles()
        {

        }
        public void ParkBus(Vehicle vehicle)
        {
        }
    }
}
