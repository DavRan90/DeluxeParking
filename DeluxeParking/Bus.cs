using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParking
{
    internal class Bus
    {
        public int NumberOfPassangers { get; set; }
        public Bus(int numberOfPassangers)
        {
            NumberOfPassangers = numberOfPassangers;
        }
    }
}
