using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;

namespace tourism_management_system
{
    internal class Program
    {
        static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Customer Management System");
                Console.WriteLine("");
                Console.WriteLine("Select position");
                Console.WriteLine("1:\tCompany owner");
                Console.WriteLine("2:\tReceptionist");
                Console.WriteLine("3:\tDriver");
                Console.WriteLine("4:\tPhotographer");
                Console.WriteLine("5:\tCustomer");
                Console.WriteLine("0:\tExit");
                int userInput;
                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    Console.Clear();
                    switch (userInput)
                    {
                        case 1:
                            Console.WriteLine("manager");
                            Manager();
                            break;
                        case 2:
                            Console.WriteLine("Receptionist");
                            Receptionest();
                            break;
                        case 3:
                            Console.WriteLine("Driver");
                            Driver();
                            break;
                        case 4:
                            Console.WriteLine("Photographer");
                            Photographer();
                            break;
                        case 5:
                            Console.WriteLine("Customer");
                            Customer();
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid input");
                }
            }
        }
        static void Manager()
        {
            Console.WriteLine("Please select and option");
            Console.WriteLine("");
            Console.WriteLine("1:\tMangerUtil");
            int userInput;
            if (int.TryParse(Console.ReadLine(), out userInput))
            {
                Console.Clear();
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("manager util");
                        ManagerUtil();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        static void Receptionest()
        {
            Console.WriteLine("Please select and option");
            Console.WriteLine("");
            Console.WriteLine("1:\tReceptionestUtil");
            int userInput;
            if (int.TryParse(Console.ReadLine(), out userInput))
            {
                Console.Clear();
                switch (userInput)
                {
                    case 1:
                        ReceptionestUtil();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        static void Driver()
        {
            Console.WriteLine("Please select and option");
            Console.WriteLine("");
            Console.WriteLine("1:\tDriver util");
            int userInput;
            if (int.TryParse(Console.ReadLine(), out userInput))
            {
                Console.Clear();
                switch (userInput)
                {
                    case 1:
                        DriverUtil ();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        static void Photographer()
        {
            Console.WriteLine("Please select and option");
            Console.WriteLine("");
            Console.WriteLine("1:\tPhotographer Util");
            int userInput;
            if (int.TryParse(Console.ReadLine(), out userInput))
            {
                Console.Clear();
                switch (userInput)
                {
                    case 1:
                        PhotographerUtil();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}