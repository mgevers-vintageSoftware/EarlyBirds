using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Service.Dto
{
    public class TicketInformation
    {
        public int Id { get; set; }
        public Priority Priority { get; set; }
        public string DevNotes { get; set; }
    }
}
