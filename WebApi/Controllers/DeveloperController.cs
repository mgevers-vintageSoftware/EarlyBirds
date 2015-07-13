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
    [RoutePrefix("developers")]
    public class DeveloperController : ApiController
    {
        [Route]
        public IHttpActionResult Get()
        {
            try
            {
                List<Dto.Developer> developers = DeveloperService.GetAllDevelopers();

                if (developers == null)
                {
                    return this.NotFound();
                }

                return this.Ok(developers);
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
                Dto.Developer developer = DeveloperService.GetDeveloper(id);
                if (developer == null)
                {
                    return this.NotFound();
                }
                return this.Ok(developer);
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
                Dto.Developer developer = DeveloperService.GetDeveloper(name);
                if (developer == null)
                {
                    return this.NotFound();
                }
                else
                {
                    return this.Ok(developer);
                }
            }
            catch (Exception e)
            {
                return this.InternalServerError(e);
            }
        }

        [Route]
        public IHttpActionResult Post(Dto.Developer developer)
        {
            try
            {
                if (developer == null)
                {
                    return this.NotFound();
                }
                DeveloperService.PostDeveloper(developer.Name, developer.PhoneNumber, developer.Email);
                return this.Created(this.Request.RequestUri.AbsolutePath + "/" + developer.Name, developer);
            }
            catch (Exception e)
            {
                return this.InternalServerError(e);
            }
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(int id, Dto.Developer developer)
        {
            try
            {
                if (developer == null)
                {
                    return this.NotFound();
                }
                bool existing = DeveloperService.PutDeveloper(id, developer.Name, developer.PhoneNumber, developer.Email);
                if (!existing)
                {
                    return this.NotFound();
                }
                else
                {
                    return this.Ok(developer);
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
                bool isDeleted = DeveloperService.DeleteDeveloper(id);
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