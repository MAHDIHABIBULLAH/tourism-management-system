namespace tourism_management_system
{
    internal class Program
    {
        static Dictionary<string, string> data = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Tourism Management System");
                Console.WriteLine("1. Save Data");
                Console.WriteLine("2. Update Data");
                Console.WriteLine("3. Remove Data");
                Console.WriteLine("4. Show All Data");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            SaveData();
                            break;
                        case 2:

                            break;
                        case 3:

                            break;
                        case 4:
                            ShowAllData();
                            break;
                        case 5:

                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

                Console.WriteLine();
            }
            static void SaveData()
            {
                Console.Write("Enter a customer first name: ");
                string firstname = Console.ReadLine();
                Console.Write("Enter a customer last name: ");
                string lastname = Console.ReadLine();
                using (StreamWriter sw = new StreamWriter(@"..\..\..\CustomerData.txt"))
                {
                    sw.WriteLine(firstname);
                    sw.WriteLine(lastname);
                }


            }
        }
    }
}