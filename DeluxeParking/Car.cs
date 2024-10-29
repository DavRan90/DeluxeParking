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
        public override void VehicleInfo()
        {
            base.VehicleInfo();
            Console.WriteLine($"Car | {LicensePlate} | Color: {Color} | Electric: {Electric}");
        }
    }
}
