
namespace DeluxeParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person(34, "David");
            
            Console.WriteLine($"Hello {person.Name}, you are {person.Age} years old");
        }
    }
}
