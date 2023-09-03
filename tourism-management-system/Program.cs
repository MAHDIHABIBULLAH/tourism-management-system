namespace tourism_management_system
{
    internal class Program
    {
        private static string customerDataFilePath = @"..\..\..\CustomerData.txt";
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
                Console.WriteLine("0. Exit");
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
                        case 0:
                            Environment.Exit(0);
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
                Console.Clear();
                Console.Write("Enter a customer first name: ");
                string firstname = Console.ReadLine();
                Console.Write("Enter a customer last name: ");
                string lastname = Console.ReadLine();
                Console.Write("Enter a customer phone number: ");
                int phoneNumber = Convert.ToInt32(Console.ReadLine());

                using (StreamWriter sw = new StreamWriter(customerDataFilePath, true))
                {
                    sw.WriteLine(firstname);
                    sw.WriteLine(lastname);
                    sw.WriteLine(phoneNumber);
                }
            }
            static void ShowAllData()
            {
                Console.Clear();
                Console.WriteLine("Customer Data:");
              
                if (File.Exists(customerDataFilePath))
                {
                    using (StreamReader sr = new StreamReader(customerDataFilePath))
                    {
                        while (!sr.EndOfStream)
                        {
                            string firstName = sr.ReadLine();
                            string lastName = sr.ReadLine();
                            int phoneNumber = Convert.ToInt32(sr.ReadLine());

                            Console.WriteLine($"First Name: {firstName}");
                            Console.WriteLine($"Last Name: {lastName}");
                            Console.WriteLine($"Phone Number: {phoneNumber}");
                            Console.WriteLine($"------------------------------------");
                        }
                    }
                    
                }
                else
                {
                    Console.WriteLine("No customer data found.");
                }
                Console.ReadLine();
            }
            static void UpdateCustomer()
            {
                Console.Clear();
                Console.WriteLine("Update Customer Data");
                Console.Write("Enter the customer's first name to update: ");
                string searchFirstName = Console.ReadLine();
                string tempFile = Path.GetTempFileName();
                bool updated = false;

                using (StreamReader sr = new StreamReader(customerDataFilePath))
                using (StreamWriter sw = new StreamWriter(tempFile))
                {
                    while (!sr.EndOfStream)
                    {
                        string firstName = sr.ReadLine();
                        string lastName = sr.ReadLine();
                        int phoneNumber = Convert.ToInt32(sr.ReadLine());
                    }
                }
            }
        }
    }
}

