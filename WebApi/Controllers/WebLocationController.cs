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
    [RoutePrefix("web-locations")]
    public class WebLocationController : ApiController
    {
        [Route]
        public IHttpActionResult Get()
        {
            try
            {
                List<Dto.WebLocation> locations = WebLocationService.GetAllWebLocations();
                return this.Ok(locations);
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
                Dto.WebLocation location = WebLocationService.GetWebLocation(id);
                if (location == null)
                {
                    return this.NotFound();
                }
                return this.Ok(location);
            }
            catch (Exception e)
            {
                return this.InternalServerError(e);
            }
        }

        [Route("{website}")]
        public IHttpActionResult Get(string website)
        {
            try
            {
                Dto.WebLocation location = WebLocationService.GetWebLocation(website);
                if (location == null)
                {
                    return this.NotFound();
                }
                return this.Ok(location);
            }
            catch (Exception e)
            {
                return this.InternalServerError(e);
            }
        }

        [Route]
        public IHttpActionResult Post(Dto.WebLocation location)
        {
            try
            {
                if (location == null)
                {
                    return this.NotFound();
                }
                location = WebLocationService.PostWebLocation(location.Url, location.Website, location.Webpage);
                return this.Created(this.Request.RequestUri.AbsolutePath + "/" + location.Url, location);
            }
            catch (Exception e)
            {
                return this.InternalServerError(e);
            }
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(int id, Dto.WebLocation location)
        {
            try
            {
                if (location == null)
                {
                    return this.NotFound();
                }
                bool existing = WebLocationService.PutWebLocation(id, location.Url, location.Website, location.Webpage);
                if (!existing)
                {
                    return this.NotFound();
                }
                else
                {
                    return this.Ok(location);
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
                bool isDeleted = WebLocationService.DeleteWebLocation(id);
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
