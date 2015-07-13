using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public enum Priority { Unset = 0, Low = 1, MedLow = 2, Med = 3, MedHigh = 4, High = 5 }

    public class TicketInformation
    {
        private static int IdNumber = 0;
        
        public TicketInformation(int id, Priority priority, string devNotes)
        {
            this.Id = id;
            this.Priority = priority;
            this.DevNotes = devNotes;
        }

        public TicketInformation(Priority priority, string devNotes)
        {
            this.Id = ++IdNumber;    
            this.Priority = priority;
            this.DevNotes = devNotes;
        }

        public int Id { get; set; }
        public Priority Priority { get; set; }
        public string DevNotes { get; set; }

        public void Update(int id, Priority priority, string devNotes)
        {
            this.Id = id;
            this.Priority = priority;
            this.DevNotes = devNotes;
        }

        public override string ToString()
        {
            return "{id = " + this.Id + ", priority = " + this.Priority + ", devNotes = " + this.DevNotes + "}";
        }
    }
}
