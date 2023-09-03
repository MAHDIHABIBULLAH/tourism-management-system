using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using ConsoleTables;

namespace tourism_management_system
{
    internal class Program
    {
        static bool CheckCredentials(string position, string password)
        {
            switch (position.ToLower())
            {
                case "owner":
                    return password == "ownerpassword";
                case "receptionist":
                    return password == "receptionistpassword";
                case "driver":
                    return password == "driverpassword";
                case "photographer":
                    return password == "photographerpassword";
                default:
                    return false;
            }
        }
            static void Main()
        {
            static int DisplayMenu()
            {
                Console.WriteLine("Select your position:");
                Console.WriteLine("1. Owner");
                Console.WriteLine("2. Receptionist");
                Console.WriteLine("3. Driver");
                Console.WriteLine("4. Photographer");

                int choice = int.Parse(Console.ReadLine());
                return choice;
            }
            int choice = DisplayMenu();

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


        static string Position(int choice)
        {
            switch (choice)
            {
                case 1:
                    return "Owner";
                case 2:
                    return "Receptionist";
                case 3:
                    return "Driver";
                case 4:
                    return "Photographer";
                default:
                    return "";
            }
  
        }
    }
}
