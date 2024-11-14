using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    internal class Bus : Vehicle
    {
        public int NumberOfPassangers { get; set; }
        public Bus(string licensePlate, string color, int numberOfPassangers) : base(licensePlate, color)
        {
            NumberOfPassangers = numberOfPassangers;
        }
        public override void WriteVehicleInfo()
        {
            base.WriteVehicleInfo();
            Console.WriteLine($"| Bus\t\t | {LicensePlate} | Color: {Color} \t| Passangers: {NumberOfPassangers} \t| ParkingFee: {ParkingFee}");
        }
    }
}
