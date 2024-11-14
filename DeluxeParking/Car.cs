using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    internal class Car : Vehicle
    {
        public bool Electric { get; set; }
        public Car(string licensePlate, string color, bool electric) : base(licensePlate, color)
        {
            Electric = electric;
        }
        public override void WriteVehicleInfo()
        {
            base.WriteVehicleInfo();
            Console.WriteLine($"| Car\t\t | {LicensePlate} | Color: {Color} \t| Electric: {Electric} \t| ParkingFee: {ParkingFee}");
        }
    }
}
