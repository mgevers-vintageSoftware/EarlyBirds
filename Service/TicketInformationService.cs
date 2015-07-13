using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dmn = Domain;
using Dto = Service.Dto;
using Service.Converters;

namespace Service
{
    public class TicketInformationService
    {
        public static List<Dto.TicketInformation> GetAllTicketInformation()
        {
            List<Dto.TicketInformation> tickets = new List<Dto.TicketInformation>();

            foreach(Dmn.TicketInformation ticket in Dmn.DummyDatabase.TicketInformation)
            {
                tickets.Add(TicketInformationConverter.ToDto(ticket));
            }
            return tickets;
        }

        public static Dto.TicketInformation GetTicketInformation(int id)
        {
            Dmn.TicketInformation ticInfo = Dmn.DummyDatabase.TicketInformation.FirstOrDefault(i => i.Id == id);
            return TicketInformationConverter.ToDto(ticInfo);
        }

        public static List<Dto.TicketInformation> GetTicketInformation(Dmn.Priority priority)
        {
            List<Dmn.TicketInformation> temp = new List<Dmn.TicketInformation>();
            List<Dto.TicketInformation> ret = new List<Dto.TicketInformation>();

            foreach (Dmn.TicketInformation info in Dmn.DummyDatabase.TicketInformation)
            {
                if (info.Priority == priority)
                {
                    temp.Add(info);
                }
            }

            foreach (Dmn.TicketInformation ticketInfo in temp)
            {
                ret.Add(TicketInformationConverter.ToDto(ticketInfo));
            }

            return ret;
        }

        public static Dto.TicketInformation PostTicketInformation(Dmn.Priority prio, string devNotes)
        {
            Dmn.TicketInformation info = new Dmn.TicketInformation(prio, devNotes);
            Dmn.DummyDatabase.TicketInformation.Add(info);
            return TicketInformationConverter.ToDto(info);
        }

        public static bool PutTicketInformation(int id, Dmn.Priority prio, string devNotes)
        {
            Dmn.TicketInformation ticketInformation = Dmn.DummyDatabase.TicketInformation.FirstOrDefault(i => i.Id == id);
            if (ticketInformation == null)
            {
                return false;
            }
            ticketInformation.Update(id, prio, devNotes);
            return true;
        }

        public static bool DeleteTicketInformation(int id)
        {
            Dmn.TicketInformation del = Dmn.DummyDatabase.TicketInformation.FirstOrDefault(i => i.Id == id);

            if (Dmn.DummyDatabase.TicketInformation.Contains(del))
            {
                Dmn.DummyDatabase.TicketInformation.Remove(del);
                return true;
            }
            return false;
        }
    }
}
