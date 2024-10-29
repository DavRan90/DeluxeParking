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
        public override void VehicleInfo()
        {
            base.VehicleInfo();
            Console.WriteLine($"Motorcycle | {LicensePlate} | Color: {Color} | Brand: {Brand}");
        }
    }
}
