using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Service;
using Dmn = Domain;
using Dto = Service.Dto;

namespace WebApi.Controllers
{
    [RoutePrefix("developer-teams")]
    public class DeveloperTeamController : ApiController
    {
        [Route]
        public IHttpActionResult Get()
        {
            try
            {
                List<Dto.DeveloperTeam> developerTeams = DeveloperTeamService.GetAllDeveloperTeams();

                if (developerTeams == null)
                {
                    return this.NotFound();
                }

                return this.Ok(developerTeams);
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
                Dto.DeveloperTeam developerTeam = DeveloperTeamService.GetDeveloperTeam(id);
                if (developerTeam == null)
                {
                    return this.NotFound();
                }
                return this.Ok(developerTeam);
            }
            catch (Exception e)
            {
                return this.InternalServerError(e);
            }
        }

        [Route("{name}")]
        public IHttpActionResult Get(string name)
        {
            try
            {
                Dto.DeveloperTeam developerTeam = DeveloperTeamService.GetDeveloperTeam(name);
                if (developerTeam == null)
                {
                    return this.NotFound();
                }
                else
                {
                    return this.Ok(developerTeam);
                }
            }
            catch (Exception e)
            {
                return this.InternalServerError(e);
            }
        }

        [Route]
        public IHttpActionResult Post(Dto.DeveloperTeam devTeam)
        {
            try
            {
                if (devTeam == null)
                {
                    return this.NotFound();
                }
                DeveloperTeamService.PostDeveloperTeam(devTeam.TeamMembers, devTeam.TeamName);
                return this.Created(this.Request.RequestUri.AbsolutePath + "/" + devTeam.TeamName, devTeam);
            }
            catch (Exception e)
            {
                return this.InternalServerError(e);
            }
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(int id, Dto.DeveloperTeam devTeam)
        {
            try
            {
                if (devTeam == null)
                {
                    return this.NotFound();
                }
                bool existing = DeveloperTeamService.PutDeveloperTeam(id, devTeam.TeamMembers, devTeam.TeamName);
                if (!existing)
                {
                    return this.NotFound();
                }
                else
                {
                    return this.Ok(devTeam);
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
                bool isDeleted = DeveloperTeamService.DeleteDeveloperTeam(id);
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
