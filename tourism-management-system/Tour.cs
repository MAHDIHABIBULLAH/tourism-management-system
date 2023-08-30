using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tourism_management_system
{
    public class Tour
    {
        private string tourName;
        private int participantCount;
        private string region;
        private string date;
        private string time;

        public string TourName { get => tourName; set => tourName = value; }
        public int ParticipantCount { get => participantCount; set => participantCount = value; }
        public string Region { get => region; set => region = value; }
        public string Date { get => date; set => date = value; }
        public string Time { get => time; set => time = value; }

        public Tour(string tourName, int participantCount, string region, string date, string time)
        {
            this.tourName = tourName;
            this.participantCount = participantCount;
            this.region = region;
            this.date = date;
            this.time = time;
        }


    }
}
