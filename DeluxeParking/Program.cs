
using System;
using System.Drawing;

namespace DeluxeParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle[,] parkedVehicles = new Vehicle[15, 2];

            while (true)
            {
                GenerateMenu(parkedVehicles);
                WriteParking(parkedVehicles);
            }
        }
        /// <summary>
        /// Write menu for choices
        /// </summary>
        /// <param name="parkedVehicles"></param>
        public static void GenerateMenu(Vehicle[,] parkedVehicles)
        {
            Console.WriteLine("==================================================================================================================");
            Console.WriteLine("1. Park vehicle");
            Console.WriteLine("2. Un-park vehicle");
            Console.WriteLine("==================================================================================================================");
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.KeyChar)
            {
                case '1':
                    Console.Clear();
                    ParkVehicle(parkedVehicles);
                    break;
                case '2':
                    UnParkVehicle(parkedVehicles);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input!");
                    break;
            }
        }
        /// <summary>
        /// Write parking information
        /// </summary>
        /// <param name="parkedVehicles"></param>
        public static void WriteParking(Vehicle[,] parkedVehicles)
        {
            Console.WriteLine("==================================================================================================================");
            for (int i = 0; i < parkedVehicles.GetLength(0); i++)
            {
                string format = "{0, -23}";
                if (parkedVehicles[i, 0] is Motorcycle)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(string.Format(format, $"Parking spot {i + 1} "));
                    parkedVehicles[i, 0].WriteVehicleInfo();
                    parkedVehicles[i, 0].ParkingFee += 1.5;
                    if (parkedVehicles[i, 1] is Motorcycle)
                    {
                        Console.Write(string.Format(format, $"Parking spot {i + 1} "));
                        parkedVehicles[i, 1].WriteVehicleInfo();
                        parkedVehicles[i, 1].ParkingFee += 1.5;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(string.Format(format, $"Parking spot {i + 1}"));
                        Console.Write("| has one more empty spot for a bike\n");
                    }
                }
                else if (parkedVehicles[i, 0] is Car)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(string.Format(format, $"Parking spot {i + 1} "));
                    parkedVehicles[i, 0].WriteVehicleInfo();
                    parkedVehicles[i, 0].ParkingFee += 1.5;
                }
                else if (parkedVehicles[i, 0] is Bus)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(string.Format(format, $"Parking spot {i + 1} and {i + 2} "));
                    parkedVehicles[i, 0].WriteVehicleInfo();
                    parkedVehicles[i, 0].ParkingFee += 3;
                    i++;
                }
                else if (parkedVehicles[i, 1] is Motorcycle)
                {
                    Console.Write(string.Format(format, $"Parking spot {i + 1}"));
                    Console.Write("| has one more empty spot for a bike\n");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(string.Format(format, $"Parking spot {i + 1} "));
                    parkedVehicles[i, 1].WriteVehicleInfo();
                    parkedVehicles[i, 1].ParkingFee += 1.5;
                }
                else
                {
                    Console.Write(string.Format(format, $"Parking spot {i + 1}"));
                    Console.Write("| is empty\n");
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        /// <summary>
        /// Method to un-park a vehicle
        /// </summary>
        /// <param name="parkedVehicles"></param>
        public static void UnParkVehicle(Vehicle[,] parkedVehicles)
        {
            Console.WriteLine("What is the license plate of the vehicle to un-park?");
            string plate = Console.ReadLine().ToUpper();
            for (int j = 0; j < parkedVehicles.GetLength(1); j++)
            {
                for (int i = 0; i < parkedVehicles.GetLength(0); i++)
                {
                    if (parkedVehicles[i, j] != null)
                    {
                        if (parkedVehicles[i, j].LicensePlate == plate || parkedVehicles[i, j].LicensePlate.Remove(3, 1) == plate)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("REMOVED:\t");
                            parkedVehicles[i, j].WriteVehicleInfo();
                            Console.Write("From spot " + (i + 1));

                            if (parkedVehicles[i, j] is Bus)
                            {
                                Console.Write(" and " + (i + 2));
                                Console.WriteLine($"\tThe cost for the parking totals: {parkedVehicles[i, j].ParkingFee} SEK");
                                Console.ForegroundColor = ConsoleColor.White;
                                parkedVehicles[i, j] = null;
                                parkedVehicles[i + 1, j] = null;
                                return;
                            }
                            else
                            {
                                Console.WriteLine($"\tThe cost for the parking totals: {parkedVehicles[i, j].ParkingFee} SEK");
                                Console.ForegroundColor = ConsoleColor.White;
                                parkedVehicles[i, j] = null;
                                return;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine($"No license plate matching {plate} - No vehicle removed\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Method to park a vehicle
        /// </summary>
        /// <param name="parkedVehicles"></param>
        public static void ParkVehicle(Vehicle[,] parkedVehicles)
        {
            Random random = new Random();
            int k = random.Next(0, 3);
            switch (k)
            {
                case 0:
                    Car car = new Car(GenerateRandomPlate(), GenerateColor(), random.Next(0, 2) == 1 ? true : false);
                    for (int i = 0; i < parkedVehicles.GetLength(0); i++)
                    {
                        if (parkedVehicles[i, 0] == null && parkedVehicles[i, 1] == null)
                        {
                            parkedVehicles[i, 0] = car;
                            break;
                        }
                    }
                    break;
                case 1:
                    Motorcycle motorcycle = new Motorcycle(GenerateRandomPlate(), GenerateColor(), "Honda");
                    for (int i = 0; i < parkedVehicles.GetLength(0); i++)
                    {
                        if (parkedVehicles[i, 0] is Motorcycle && parkedVehicles[i, 1] == null)
                        {
                            parkedVehicles[i, 1] = motorcycle;
                            break;
                        }
                        else if (parkedVehicles[i, 0] == null)
                        {
                            parkedVehicles[i, 0] = motorcycle;
                            break;
                        }
                    }
                    break;
                case 2:
                    Bus bus = new Bus(GenerateRandomPlate(), GenerateColor(), random.Next(20, 40));
                    for (int i = parkedVehicles.GetLength(0) - 1; i > 0; i--)
                    {
                        if (parkedVehicles[i, 0] == null && parkedVehicles[i, 1] == null && parkedVehicles[i - 1, 0] == null)
                        {
                            parkedVehicles[i, 0] = bus;
                            parkedVehicles[i - 1, 0] = bus;
                            break;
                        }
                    }
                    break;
            }
        }
        /// <summary>
        /// Method to generate a random license plate
        /// </summary>
        /// <returns>A randomly generated plate</returns>
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
        /// <summary>
        /// Generates a random color
        /// </summary>
        /// <returns>A random color</returns>
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
