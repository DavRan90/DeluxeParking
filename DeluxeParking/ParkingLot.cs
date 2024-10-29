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
        public ParkingLot(int parkingSpaces)
        {
            ParkingSpaces = parkingSpaces;
        }
    }
}
