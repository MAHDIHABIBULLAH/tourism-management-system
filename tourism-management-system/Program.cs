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
            }
        }
    }
}