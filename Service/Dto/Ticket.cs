using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class Ticket
    {
        public TicketInformation TicketInfo { get; set; }
        public Customer ContactInfo { get; set; }
        public Feature FeatureToFix { get; set; }
    }
}
