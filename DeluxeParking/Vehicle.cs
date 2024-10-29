using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    class Vehicle
    {
        public string LicensePlate { get; set; }
        public string Color { get; set; }
        public Vehicle(string licensePlate, string color)
        {
            LicensePlate = licensePlate;
            Color = color;
        }
    }
}
