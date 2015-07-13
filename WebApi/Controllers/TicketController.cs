using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Service;
using Dmn = Domain;
using Dto = Service.Dto;

namespace WebApi.Controllers
{
    [RoutePrefix("tickets")]
    public class TicketController : ApiController
    {
        public static string GetEnum(string value)
        {
            if (value == null)
            {
                return null;
            }
            value = value.ToLower(CultureInfo.InvariantCulture);
            switch (value)
            {
                case "high":
                    value = "High";
                    break;
                case "medhigh":
                    value = "MedHigh";
                    break;
                case "med":
                    value = "Med";
                    break;
                case "medlow":
                    value = "MedLow";
                    break;
                case "low":
                    value = "Low";
                    break;
                default:
                    break;
            }
            return value;
        }

        [Route]
        public IHttpActionResult Get()
        {
            try
            {
                List<Dto.Ticket> tickets = TicketService.GetAllTickets();
                return this.Ok(tickets);
            }
            catch (Exception e)
            {
                return this.InternalServerError(e);
            }
        }

        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Dto.Ticket ticket = TicketService.GetTicket(id);
                if (ticket == null)
                {
                    return this.NotFound();
                }
                return this.Ok(ticket);
            }
            catch (Exception e)
            {
                return this.InternalServerError(e);
            }
        }

        [Route("{priority}")]
        public IHttpActionResult Get(string priority)
        {
            try
            {
                priority = GetEnum(priority);
                List<Dto.Ticket> tickets = TicketService.GetTicket((Dmn.Priority)Enum.Parse(typeof(Dmn.Priority), priority));
                if (tickets.Count == 0)
                {
                    return this.NotFound();
                }
                else
                {
                    return this.Ok(tickets);
                }
            }
            catch (Exception e)
            {
                return this.InternalServerError(e);
            }
        }

        [Route]
        public IHttpActionResult Post(Dto.Ticket ticket)
        {
            try
            {
                if (ticket == null)
                {
                    return this.NotFound();
                }
                TicketService.PostTicket(
                    ticket.TicketInfo.Priority,
                    ticket.TicketInfo.DevNotes,
                    ticket.ContactInfo.Name,
                    ticket.ContactInfo.Email,
                    ticket.ContactInfo.PhoneNumber,
                    ticket.ContactInfo.Message,
                    ticket.ContactInfo.TwitterHandle,
                    ticket.ContactInfo.FacebookName,
                    ticket.ContactInfo.ContactMethod,
                    ticket.FeatureToFix.Location.Url,
                    ticket.FeatureToFix.Location.Website,
                    ticket.FeatureToFix.Location.Webpage,
                    ticket.FeatureToFix.Team.TeamMembers,
                    ticket.FeatureToFix.Team.TeamName,
                    ticket.FeatureToFix.Team.Id,
                    ticket.FeatureToFix.IsBroken,
                    ticket.FeatureToFix.Name);
                return this.Created(this.Request.RequestUri.AbsolutePath + "/" + ticket.FeatureToFix.Name, ticket);
            }
            catch (Exception e)
            {
                return this.InternalServerError(e);
            }
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(int id, Dto.Ticket ticket)
        {
            try
            {
                if (ticket == null)
                {
                    return this.NotFound();
                }
                bool existing = TicketService.PutTicket(
                    id,
                    ticket.TicketInfo.Priority,
                    ticket.TicketInfo.DevNotes,
                    ticket.ContactInfo.Name,
                    ticket.ContactInfo.Email,
                    ticket.ContactInfo.PhoneNumber,
                    ticket.ContactInfo.Message,
                    ticket.ContactInfo.TwitterHandle,
                    ticket.ContactInfo.FacebookName,
                    ticket.ContactInfo.ContactMethod,
                    ticket.FeatureToFix.Location.Url,
                    ticket.FeatureToFix.Location.Website,
                    ticket.FeatureToFix.Location.Webpage,
                    ticket.FeatureToFix.Team.TeamMembers,
                    ticket.FeatureToFix.Team.TeamName,
                    ticket.FeatureToFix.Team.Id,
                    ticket.FeatureToFix.IsBroken,
                    ticket.FeatureToFix.Name);
                if (!existing)
                {
                    return this.NotFound();
                }
                else
                {
                    return this.Ok(ticket);
                }
            }
            catch (Exception e)
            {
                return this.InternalServerError(e);
            }
        }

        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                bool isDeleted = TicketService.DeleteTicket(id);
                if (!isDeleted)
                {
                    return this.NotFound();
                }
                else
                {
                    return this.StatusCode(HttpStatusCode.NoContent);
                }
            }
            catch (Exception e)
            {
                return this.InternalServerError(e);
            }
        }
    }
}