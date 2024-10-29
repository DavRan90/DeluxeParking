
using System;

namespace DeluxeParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParkingLot parking = new ParkingLot(15);
            List<Vehicle> vehicles = new List<Vehicle>();
            Random random = new Random();
            while (true)
            {
                GenerateMenu(vehicles);
                for (int i = 0; i < vehicles.Count; i++)
                {
                    
                    vehicles[i].VehicleInfo();
                }
            }

            

        }
        public static void GenerateMenu(List<Vehicle> vehicles)
        {
            Random random = new Random();
            Console.WriteLine("==========================");
            Console.WriteLine("1. Park car");
            Console.WriteLine("2. Park motorcycle");
            Console.WriteLine("3. Park bus");
            Console.WriteLine("==========================");
            ConsoleKeyInfo key = Console.ReadKey(true);
            Console.Clear();
            switch (key.KeyChar)
            {
                case '1':
                    Car car = new Car(GenerateRandomPlate(), GenerateColor(), random.Next(0, 2) == 1 ? true : false);
                    vehicles.Add(car);
                    break;
                case '2':
                    Motorcycle motorcycle = new Motorcycle(GenerateRandomPlate(), GenerateColor(), "Honda");
                    vehicles.Add(motorcycle);
                    break;
                case '3':
                    Bus bus = new Bus(GenerateRandomPlate(), GenerateColor(), random.Next(20, 40));
                    vehicles.Add(bus);
                    break;

            }

        }
        public static string GenerateRandomPlate()
        {
            Random random = new Random();
            string plate = "";
            for (int i = 0; i < 3; i++)
            {
                char c = (char)('A' + random.Next(0, 26));
                plate += c;
            }
            plate += " ";
            for (int i = 0; i < 3; i++)
            {
                int t = (char)(random.Next(0, 10));
                plate += t;
            }

            return plate;
        }
        public static string GenerateColor()
        {
            Random random = new Random();
            string color = "";
            string[] colors = { "Red", "White", "Blue", "Yelllow", "Black", "Silver" };
            color = colors[random.Next(0, colors.Length)];
            return color;
        }
    }
}
