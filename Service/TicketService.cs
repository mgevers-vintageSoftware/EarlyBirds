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
    public class TicketService
    {
        public static List<Dto.Ticket> GetAllTickets()
        {
            List<Dto.Ticket> Tickets = new List<Dto.Ticket>();

            foreach (Dmn.Ticket ticket in Dmn.DummyDatabase.Tickets)
            {
                Tickets.Add(TicketConverter.ToDto(ticket));
            }

            return Tickets;
        }

        public static Dto.Ticket GetTicket(int id)
        {
            Dmn.Ticket ticket = Dmn.DummyDatabase.Tickets.FirstOrDefault(i => i.TicketInfo.Id == id);
            return TicketConverter.ToDto(ticket);
        }

        public static List<Dto.Ticket> GetTicket(Dmn.Priority priority)
        {
            List<Dmn.Ticket> temp = new List<Domain.Ticket>();
            List<Dto.Ticket> ret = new List<Dto.Ticket>();

            foreach (Dmn.Ticket ticket in Dmn.DummyDatabase.Tickets)
            {
                if (ticket.TicketInfo.Priority == priority)
                {
                    temp.Add(ticket);
                }
            }

            foreach (Dmn.Ticket ticket in temp)
            {
                ret.Add(TicketConverter.ToDto(ticket));
            }

            return ret;
        }

        public static Dto.Ticket PostTicket(
            Dmn.Priority prio,
            string devnotes,
            string name,
            string email,
            string phoneNumber,
            string message,
            string twitterHandle,
            string facebookName,
            string contactMethod,
            string url,
            string website,
            string webpage,
            List<Dto.Developer> devs,
            string teamName,
            int teamId, 
            bool isBroken, 
            string featureName)
        {
            List<Dmn.Developer> dmnDevs = new List<Domain.Developer>();

            foreach (Dto.Developer dev in devs)
            {
                dmnDevs.Add(new Dmn.Developer(dev.Name, dev.PhoneNumber, dev.Email));
            }
            Dmn.WebLocation location = new Dmn.WebLocation(url, website, webpage);
            Dmn.DeveloperTeam team = new Dmn.DeveloperTeam(teamId, dmnDevs, teamName);
            Dmn.TicketInformation info = new Dmn.TicketInformation(prio, devnotes);
            Dmn.Customer customer = new Dmn.Customer(name, email, phoneNumber, message, twitterHandle, facebookName, contactMethod);
            Dmn.Feature feature = new Dmn.Feature(location, team, isBroken, featureName);

            Dmn.Ticket ticket = new Dmn.Ticket(info, customer, feature);
            Dmn.DummyDatabase.Tickets.Add(ticket);
            return TicketConverter.ToDto(ticket);
        }

        public static bool PutTicket(
            int tid,
            Dmn.Priority prio,
            string devnotes,
            string name,
            string email,
            string phoneNumber,
            string message,
            string twitterHandle,
            string facebookName,
            string contactMethod,
            string url,
            string website,
            string webpage,
            List<Dto.Developer> devs,
            string teamName,
            int teamId,
            bool isBroken,
            string featureName)
        {
            Dmn.Ticket ticket = Dmn.DummyDatabase.Tickets.FirstOrDefault(i => i.TicketInfo.Id == tid);
            if (ticket == null)
            {
                return false;
            }

            List<Dmn.Developer> dmnDevs = new List<Domain.Developer>();

            foreach (Dto.Developer dev in devs)
            {
                dmnDevs.Add(new Dmn.Developer(dev.Name, dev.PhoneNumber, dev.Email));
            }

            Dmn.WebLocation location = new Dmn.WebLocation(url, website, webpage);
            Dmn.DeveloperTeam team = new Dmn.DeveloperTeam(teamId, dmnDevs, teamName);
            Dmn.TicketInformation info = new Dmn.TicketInformation(tid, prio, devnotes);
            Dmn.Customer customer = new Dmn.Customer(name, email, phoneNumber, message, twitterHandle, facebookName, contactMethod);
            Dmn.Feature feature = new Dmn.Feature(location, team, isBroken, featureName);

            ticket.Update(info, customer, feature);
            return true;
        }

        public static bool DeleteTicket(int id)
        {
            Dmn.Ticket del = Dmn.DummyDatabase.Tickets.FirstOrDefault(i => i.TicketInfo.Id == id);

            if (Dmn.DummyDatabase.Tickets.Contains(del))
            {
                Dmn.DummyDatabase.Tickets.Remove(del);
                return true;
            }
            return false;
        }
    }
}
