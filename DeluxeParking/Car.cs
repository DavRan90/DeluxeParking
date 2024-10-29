using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    internal class Car
    {
        public bool Electric { get; set; }
        public Car(bool electric)
        {
            Electric = electric;
        }
    }
}
