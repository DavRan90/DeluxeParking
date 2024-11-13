
using System;
using System.Drawing;

namespace DeluxeParking
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Vehicle> vehicles = new List<Vehicle>();
            //Vehicle[,] vehicles = new Vehicle[16, 2];

            //ParkingLot parking = new ParkingLot(15, vehicles);
            ParkingSpot[,] parkingLot = new ParkingSpot[16,2];
            Random random = new Random();
            while (true)
            {
                
                GenerateMenu(vehicles, parkingLot);
                for (int i = 0; i < vehicles.Count; i++)
                {
                    Console.Write("Parking spot " + (i+1) + " | ");
                    vehicles[i].VehicleInfo();
                }
                
            }

            

        }
        public static void GenerateMenu(List<Vehicle> vehicles, ParkingSpot[,] parkingLot)
        {
            
            Console.WriteLine("==========================");
            Console.WriteLine("1. Park vehicle");
            Console.WriteLine("2. Un-park vehicle");
            Console.WriteLine("3. ------");
            Console.WriteLine("==========================");
            ConsoleKeyInfo key = Console.ReadKey(true);
            
            switch (key.KeyChar)
            {
                case '1':
                    Console.Clear();
                    
                    ParkVehicle(vehicles, parkingLot);
                    
                    break;
                case '2':
                    Console.WriteLine("What is the license plate of the car to un-park?");
                    string plate = Console.ReadLine().ToUpper();
                    for (int i = 0; i < vehicles.Count; i++)
                    {
                        if (vehicles[i].LicensePlate == plate || vehicles[i].LicensePlate.Remove(3, 1) == plate)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("REMOVED: ");
                            vehicles[i].VehicleInfo();
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            vehicles.RemoveAt(i);
                            return;
                        }
                    }
                    Console.Clear();
                    Console.WriteLine("No matching license plate - No car removed");
                    break;
                case '3':
                    break;
            }
            
            
        }
        public static void ParkVehicle(List<Vehicle> vehicles, ParkingSpot[,] parkingLot)
        {
            Random random = new Random();
            int k = random.Next(0, 3);
            switch (k)
            {
                case 0:
                    Car car = new Car(GenerateRandomPlate(), GenerateColor(), random.Next(0, 2) == 1 ? true : false);
                    vehicles.Add(car);
                    //parkingLot[0, 0] = car;
                    break;
                case 1:
                    Motorcycle motorcycle = new Motorcycle(GenerateRandomPlate(), GenerateColor(), "Honda");
                    vehicles.Add(motorcycle);
                    break;
                case 2:
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
