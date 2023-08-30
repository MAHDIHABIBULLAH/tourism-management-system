using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using ConsoleTables;

namespace tourism_management_system
{
    internal class Program
    {
        private static List<Tour> tours = new List<Tour>();
        private static string databaseFilePath = @"..\..\..\tourDatabase.txt";

        public static void LoadDatabase()
        {
            using (StreamReader reader = new StreamReader(databaseFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] split = line.Split(",");
                    tours.Add(new Tour(split[0], Convert.ToInt32(split[1]), split[2], split[3], split[4]));
                }
            }
        }

        public static void SaveDatabase()
        {
            using (StreamWriter writer = new StreamWriter(databaseFilePath))
            {
                foreach (Tour tour in tours)
                {
                    writer.WriteLine($"{tour.TourName},{tour.ParticipantCount},{tour.Region},{tour.Date},{tour.Time}");
                }

            }
        }

        public static void DisplayTourInformation()
        {
            Console.Clear();
            Database();
        }

        public static void TrackParticipantCount()
        {
            Console.Clear();
            Console.Write("Enter tour name: ");
            string tourName = Console.ReadLine() ?? string.Empty;
            Tour existingTour = tours.Find(tour => tour.TourName == tourName);
            if (existingTour != null)
            {
                ConsoleTable table = new ConsoleTable("Tour Name", "No. of Participants", "Region", "Date", "Time");
                table.AddRow(existingTour.TourName, existingTour.ParticipantCount, existingTour.Region, existingTour.Date, existingTour.Time);
                Console.Write("Physically count the number of participants for the tour and enter: ");
                int participantCount = Convert.ToInt32(Console.ReadLine());
                if (participantCount == existingTour.ParticipantCount)
                {
                    Console.WriteLine("The participant count matches the database.");
                }
                else
                {
                    Console.WriteLine("Participant count mismatch. Please investigate and report to the stakeholders.");
                    Console.WriteLine("After confirming with stakeholders update the actual participant count in the database.");
                    Console.Write("Enter decision by stakeholders(YES/NO): ");
                    string decision = Console.ReadLine() ?? string.Empty.ToUpper();
                    if (decision == "YES")
                    {
                        foreach (Tour tour in tours)
                        {
                            if (tour.TourName == tourName)
                            {
                                tour.ParticipantCount = participantCount;
                                break;
                            }
                        }
                        SaveDatabase();
                        Console.WriteLine("The database has been updated.");
                    }
                    else
                    {
                        Console.WriteLine("The stakeholders did not give permission to update the actual participants in the tour and postponed the tour.");
                    }
                }
            }
            else
            {
                Console.WriteLine("The tour does not exist in the database. Ask the customers to check with reception.");
            }
        }

        public static void GenerateStakeHolderReport()
        {
            Console.Clear();
            Console.WriteLine("Stakeholder Report");
            Console.WriteLine("-------------------");
            Console.WriteLine("Updated details of the tour with actual no. of participants.");
            Database();
           
        }

        public static void Database()
        {
            ConsoleTable table = new ConsoleTable("Tour Name", "No. of Participants", "Region", "Date", "Time");
            foreach (Tour tour in tours)
            {
                table.AddRow(tour.TourName, tour.ParticipantCount, tour.Region, tour.Date, tour.Time);
            }
            table.Write();
        }

        public static void MenuSystemDriver()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Display Tour Information");
            Console.WriteLine("2. Track Participant Count");
            Console.WriteLine("3. Generate Stakeholder Report");
            Console.WriteLine("4. Exit");
            Console.WriteLine("");
            Console.Write("Enter your choice: ");
        }
        static void Main(string[] args)
        {
            string userInput;
            int userChoice;
            LoadDatabase();
            do
            {
                MenuSystemDriver();
                userInput = Console.ReadLine() ?? string.Empty;
                while (!int.TryParse(userInput, out userChoice))
                {
                    Console.WriteLine("Invalid Selection. Please enter your choice again: ");
                    userInput = Console.ReadLine() ?? string.Empty; ;
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