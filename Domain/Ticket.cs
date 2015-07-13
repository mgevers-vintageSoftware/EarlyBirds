using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Ticket
    {
        public Ticket(TicketInformation ticketInfo, Customer contactInfo, Feature feature)
        {
            this.TicketInfo = ticketInfo;
            this.FeatureToFix = feature;
            this.ContactInfo = contactInfo;
        }

        public TicketInformation TicketInfo { get; private set; }
        public Customer ContactInfo { get; private set; }
        public Feature FeatureToFix { get; private set; } 

        public void Update(TicketInformation ticketInfo, Customer contactInfo, Feature feature)
        {
            this.TicketInfo = ticketInfo;
            this.FeatureToFix = feature;
            this.ContactInfo = contactInfo;
        }

        public override string ToString()
        {
            return this.TicketInfo.ToString() + "\n" + this.ContactInfo.ToString() + "\n" + this.FeatureToFix.ToString();
        }
    }
}