namespace tourism_management_system
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Select your position:");
            Console.WriteLine("1. Owner");
            Console.WriteLine("2. Receptionist");
            Console.WriteLine("3. Driver");
            Console.WriteLine("4. Photographer");

            int choice = int.Parse(Console.ReadLine());

            string position = Position(choice);

            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();

            if (CheckCredentials(position, password))
            {
                Console.WriteLine("Access granted.");
            }
            else
            {
                Console.WriteLine("Access denied.");
            }

            Console.ReadLine();
        }
    }
    }
}