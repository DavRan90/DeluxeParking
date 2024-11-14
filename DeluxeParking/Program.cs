
using System;
using System.Drawing;

namespace DeluxeParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle[,] vehicles = new Vehicle[16, 2];

            Random random = new Random();
            while (true)
            {
                GenerateMenu(vehicles);
                WriteGarage(vehicles);
            }
        }
        public static void WriteGarage(Vehicle[,] vehicles)
        {
            for (int i = 0; i < vehicles.GetLength(0); i++)
            {
                if (vehicles[i, 0] is Motorcycle)
                {
                    Console.Write("Parking spot " + (i + 1) + " | ");
                    vehicles[i, 0].VehicleInfo();
                    if (vehicles[i, 1] != null)
                    {
                        Console.Write("Parking spot " + (i + 1) + " | ");
                        vehicles[i, 1].VehicleInfo();
                    }
                    else
                    {
                        Console.WriteLine("Parking spot " + (i + 1) + " | has one more empty spot for a bike");
                    }
                }
                else if (vehicles[i, 0] != null)
                {
                    Console.Write("Parking spot " + (i + 1) + " | ");
                    vehicles[i, 0].VehicleInfo();
                }
                else if (vehicles[i, 1] != null)
                {
                    Console.WriteLine("Parking spot " + (i + 1) + " | has one more empty spot for a bike");
                    Console.Write("Parking spot " + (i + 1) + " | ");
                    vehicles[i, 1].VehicleInfo();
                }
                else
                {
                    Console.WriteLine("Parking spot " + (i + 1) + " | is empty");
                }
            }
        }
        public static void GenerateMenu(Vehicle[,] vehicles)
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
                    ParkVehicle(vehicles);
                    break;
                case '2':
                    UnParkVehicle(vehicles);
                    break;
                case '3':
                    break;
            }
        }
        public static void UnParkVehicle(Vehicle[,] vehicles)
        {
            Console.WriteLine("What is the license plate of the vehicle to un-park?");
            string plate = Console.ReadLine().ToUpper();
            for (int j = 0; j < vehicles.GetLength(1); j++)
            {
                for (int i = 0; i < vehicles.GetLength(0); i++)
                {
                    if (vehicles[i, j] != null)
                    {
                        if (vehicles[i, j].LicensePlate == plate || vehicles[i, j].LicensePlate.Remove(3, 1) == plate)
                        {
                            if (vehicles[i, j] is Bus)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("REMOVED: ");
                                vehicles[i, j].VehicleInfo();
                                Console.WriteLine("From spot " + (i + 1) + " and " + (i + 2));
                                Console.ForegroundColor = ConsoleColor.White;
                                vehicles[i, j] = null;
                                vehicles[i + 1, j] = null;
                                return;
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("REMOVED: ");
                                vehicles[i, j].VehicleInfo();
                                Console.WriteLine("From spot " + (i + 1));
                                Console.ForegroundColor = ConsoleColor.White;
                                vehicles[i, j] = null;
                                return;
                            }

                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("No matching license plate - No vehicle removed\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
            }
        }
        public static void ParkVehicle(Vehicle[,] vehicles)
        {
            Random random = new Random();
            int k = random.Next(0, 3);
            switch (k)
            {
                case 0:
                    Car car = new Car(GenerateRandomPlate(), GenerateColor(), random.Next(0, 2) == 1 ? true : false);
                    for (int i = 0; i < vehicles.GetLength(0); i++)
                    {
                        if (vehicles[i, 0] == null && vehicles[i, 1] == null)
                        {
                            vehicles[i, 0] = car;
                            break;
                        }
                    }
                    break;
                case 1:
                    Motorcycle motorcycle = new Motorcycle(GenerateRandomPlate(), GenerateColor(), "Honda");
                    for (int i = 0; i < vehicles.GetLength(0); i++)
                    {
                        if (vehicles[i, 0] is Motorcycle && vehicles[i, 1] == null)
                        {
                            vehicles[i, 1] = motorcycle;
                            break;
                        }
                        else if (vehicles[i, 0] == null)
                        {
                            vehicles[i, 0] = motorcycle;
                            break;
                        }
                    }
                    break;
                case 2:
                    Bus bus = new Bus(GenerateRandomPlate(), GenerateColor(), random.Next(20, 40));
                    for (int i = vehicles.GetLength(0) - 1; i > 0; i--)
                    {
                        if (vehicles[i, 0] == null && vehicles[i, 1] == null && vehicles[i - 1, 0] == null)
                        {
                            vehicles[i, 0] = bus;
                            vehicles[i - 1, 0] = bus;
                            break;
                        }
                    }
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
