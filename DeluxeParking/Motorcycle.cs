using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    internal class Motorcycle : Vehicle
    {
        public string Brand { get; set; }
        public Motorcycle(string licensePlate, string color, string brand) : base(licensePlate, color)
        {
            Brand = brand;
        }
        public override void WriteVehicleInfo()
        {
            base.WriteVehicleInfo();
            Console.WriteLine($"| Motorcycle\t | {LicensePlate} | Color: {Color} \t| Brand: {Brand} \t\t| ParkingFee: {ParkingFee}");
        }
    }
}
