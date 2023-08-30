namespace tourism_management_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            int userChoice;
            LoadDatabase();
            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Display Tour Information");
                Console.WriteLine("2. Track Participant Count");
                Console.WriteLine("3. Generate Stakeholder Report");
                Console.WriteLine("4. Exit");
                Console.WriteLine("");
                Console.Write("Enter your choice: ");
                userInput = Console.ReadLine();
                while (!int.TryParse(userInput, out userChoice))
                {
                    Console.WriteLine("Invalid Selection. Please enter your choice again: ");
                    userInput = Console.ReadLine();
                }
                switch (userChoice)
                {
                    case 1:
                        DisplayTourInformation();
                        break;
                    case 2:
                        TrackParticipantCount();
                        break;
                    case 3:
                        GenerateStakeHolderReport();
                        break;
                    case 4:
                        SaveDatabase();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Write("Invalid Selection. Please enter your choice again: ");
                        break;
                }
            } while (userChoice != 4);
        }
    }
}