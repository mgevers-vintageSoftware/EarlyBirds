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
    [RoutePrefix("ticket-information")]
    public class TicketInformationController : ApiController
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
                List<Dto.TicketInformation> ticInfo = TicketInformationService.GetAllTicketInformation();

                if (ticInfo == null)
                {
                    return this.NotFound();
                }

                return this.Ok(ticInfo);
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
                Dto.TicketInformation customer = TicketInformationService.GetTicketInformation(id);
                if (customer == null)
                {
                    return this.NotFound();
                }
                return this.Ok(customer);
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
                List<Dto.TicketInformation> ticInfo = TicketInformationService.GetTicketInformation((Dmn.Priority)Enum.Parse(typeof(Dmn.Priority), priority));
                if (ticInfo.Count == 0)
                {
                    return this.NotFound();
                }
                else
                {
                    return this.Ok(ticInfo);
                }
            }
            catch (Exception e)
            {
                return this.InternalServerError(e);
            }
        }

        [Route]
        public IHttpActionResult Post(Dto.TicketInformation ticInfo)
        {
            try
            {
                if (ticInfo == null)
                {
                    return this.NotFound();
                }
                TicketInformationService.PostTicketInformation(ticInfo.Priority, ticInfo.DevNotes);
                return this.Created(this.Request.RequestUri.AbsolutePath + "/" + ticInfo.Id, ticInfo);
            }
            catch (Exception e)
            {
                return this.InternalServerError(e);
            }
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(int id, Dto.TicketInformation ticInfo)
        {
            try
            {
                if (ticInfo == null)
                {
                    return this.NotFound();
                }
                bool existing = TicketInformationService.PutTicketInformation(id, ticInfo.Priority, ticInfo.DevNotes);
                if (!existing)
                {
                    return this.NotFound();
                }
                else
                {
                    return this.Ok(ticInfo);
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
                bool isDeleted = TicketInformationService.DeleteTicketInformation(id);
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
