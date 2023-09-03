using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using ConsoleTables;

namespace tourism_management_system
{
    internal class Program
    {
        private static List<Tour> tours = new List<Tour>();
        private static List<Tour> assignedTours = new List<Tour>();
        private static string databaseFilePath = @"..\..\..\tourDatabase.txt";

        public static void LoadDatabase()
        {
            using (StreamReader reader = new StreamReader(databaseFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] split = line.Split(",");
                    tours.Add(new Tour(split[0], Convert.ToInt32(split[1]), split[2], split[3], split[4], Convert.ToInt32(split[5]), split[6]));
                }
            }
        }

        public static void SaveDatabase()
        {
            using (StreamWriter writer = new StreamWriter(databaseFilePath))
            {
                foreach (Tour tour in tours)
                {
                    writer.WriteLine($"{tour.TourName},{tour.ParticipantCount},{tour.Region},{tour.Date},{tour.Time},{tour.ActualParticipantCount},{tour.VehicleAssigned}");
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
                ConsoleTable table = new ConsoleTable("Tour Name", "No. of Participants", "Region", "Date", "Time", "Actual Participants");
                table.AddRow(existingTour.TourName, existingTour.ParticipantCount, existingTour.Region, existingTour.Date, existingTour.Time, existingTour.ActualParticipantCount);
                table.Write();
                if (existingTour.ActualParticipantCount > 0)
                {
                    Console.WriteLine("The actual participant count has already been set.");
                }
                else
                {
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
                        foreach (Tour tour in tours)
                        {
                            if (tour.TourName == tourName)
                            {
                                tour.ActualParticipantCount = participantCount;
                                break;
                            }
                        }
                        SaveDatabase();
                        Console.WriteLine("The database has been updated.");
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
            Console.Write("Enter the name of the tour: ");
            string tourName = Console.ReadLine();
            Console.WriteLine(" ");
            Console.WriteLine("Updated details of the tour with actual no. of participants.");
            Tour existingTour = tours.Find(tour => tour.TourName == tourName);
            if (existingTour != null)
            {
                ConsoleTable table = new ConsoleTable("Tour Name", "No. of Participants", "Region", "Date", "Time", "Actual Participants", "Additional Vehicle Assigned");
                table.AddRow(existingTour.TourName, existingTour.ParticipantCount, existingTour.Region, existingTour.Date, existingTour.Time, existingTour.ActualParticipantCount, existingTour.VehicleAssigned);
                table.Write();
                Console.WriteLine("");
                if (assignedTours.Contains(existingTour) || existingTour.VehicleAssigned != "None")
                {
                    Console.WriteLine($"The tour {existingTour.TourName} has {existingTour.ActualParticipantCount - 16} exceeding participants than our total vehicle capacity.");
                    Console.WriteLine($"Additional vehicle {existingTour.VehicleAssigned} has been assigned to {existingTour.TourName}");
                }
                else if(existingTour.ActualParticipantCount -16 <= 0)
                {
                    if(existingTour.ActualParticipantCount == 0)
                    {
                        Console.WriteLine("The physical counting of the actual participants is not done.");
                    }
                    else
                    {
                        Console.WriteLine("No additional vehicle required for the tour.");
                    }
                }
                else
                {
                    Console.WriteLine("The tour has not been assigned a vehicle.");
                }
            }
            else
            {
                Console.WriteLine("The tour does not exist in the database");
            }
        }

        public static void RequestAdditionalVehicles()
        {
            Console.Clear();
            Console.Write("Enter tour name: ");
            string tourName = Console.ReadLine() ?? string.Empty;
            Tour existingTour = tours.Find(tour => tour.TourName == tourName);
            if (existingTour != null)
            {
                if (assignedTours.Contains(existingTour) || existingTour.VehicleAssigned != "None")
                {
                    Console.WriteLine($"Additional vehicle {existingTour.VehicleAssigned} has already been assigned to '{existingTour.TourName}'.");
                    return;
                }

                int exceedingParticipants = existingTour.ActualParticipantCount - 16; 
                if (exceedingParticipants > 0)
                {
                    Console.WriteLine($"The tour '{existingTour.TourName}' has {exceedingParticipants} exceeding participants than our total vehicle capacity.");
                    AssignVehicle(existingTour, exceedingParticipants);
                    assignedTours.Add(existingTour);
                    foreach (Tour tour in tours)
                    {
                        if(tour.TourName == tourName)
                        {
                            tour.VehicleAssigned = existingTour.VehicleAssigned;
                        }
                    }
                    SaveDatabase();
                }
                else if (existingTour.ActualParticipantCount - 16 <= 0)
                {
                    if (existingTour.ActualParticipantCount == 0)
                    {
                        Console.WriteLine("The physical counting of the actual participants is not done.");
                    }
                    else
                    {
                        Console.WriteLine("No additional vehicle required for the tour.");
                    }

                }
            }
            else
            {
                Console.WriteLine("The tour does not exist in the database.");
            }
        }

        public static void AssignVehicle(Tour tour, int exceedingParticipants)
        {
            if (exceedingParticipants <= 4)
            {
                Console.WriteLine("Assigning a car for additional participants.");
                tour.VehicleAssigned = "Car";
            }
            else if (exceedingParticipants <= 10)
            {
                Console.WriteLine("Assigning a jeep for additional participants.");
                tour.VehicleAssigned = "Jeep";
            }
            else
            {
                Console.WriteLine("Assigning a bus for additional participants.");
                tour.VehicleAssigned = "Bus";
            }
        }

        public static void Database()
        {
            ConsoleTable table = new ConsoleTable("Tour Name", "No. of Participants", "Region", "Date", "Time", "Actual Participants");
            foreach (Tour tour in tours)
            {
                table.AddRow(tour.TourName, tour.ParticipantCount, tour.Region, tour.Date, tour.Time, tour.ActualParticipantCount);
            }
            table.Write();
        }

        public static void MenuSystemDriver()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Display Tour Information");
            Console.WriteLine("2. Track Participant Count");
            Console.WriteLine("3. Generate Stakeholder Report");
            Console.WriteLine("4. Request Additional Vehicles");
            Console.WriteLine("5. Exit");
            Console.WriteLine("");
            Console.Write("Enter your choice: ");
        }

        public static void Driver()
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
                        RequestAdditionalVehicles();
                        break;
                    case 5:
                        SaveDatabase();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Write("Invalid Selection. Please enter your choice again: ");
                        break;
                }
            } while (userChoice != 5);
        }
        static void Main(string[] args)
        {
            
        }
    }
}