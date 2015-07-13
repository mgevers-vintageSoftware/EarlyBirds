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
    [RoutePrefix("features")]
    public class FeatureController : ApiController
    {
        [Route]
        public IHttpActionResult Get()
        {
            try
            {
                List<Dto.Feature> features = FeatureService.GetAllFeatures();

                if (features == null)
                {
                    return this.NotFound();
                }

                return this.Ok(features);
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
                Dto.Feature features = FeatureService.GetFeature(id);
                if (features == null)
                {
                    return this.NotFound();
                }
                return this.Ok(features);
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
                Dto.Feature features = FeatureService.GetFeature(name);
                if (features == null)
                {
                    return this.NotFound();
                }
                else
                {
                    return this.Ok(features);
                }
            }
            catch (Exception e)
            {
                return this.InternalServerError(e);
            }
        }

        [Route]
        public IHttpActionResult Post(Dto.Feature feature)
        {
            try
            {
                if (feature == null)
                {
                    return this.NotFound();
                }
                FeatureService.PostFeature(feature.Location.Url, feature.Location.Website, feature.Location.Webpage, feature.Team.Id, feature.Team.TeamMembers, feature.Team.TeamName, feature.IsBroken, feature.Name);
                return this.Created(this.Request.RequestUri.AbsolutePath + "/" + feature.Name, feature);
            }
            catch (Exception e)
            {
                return this.InternalServerError(e);
            }
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(int id, Dto.Feature feature)
        {
            try
            {
                if (feature == null)
                {
                    return this.NotFound();
                }
                bool existing = FeatureService.PutFeature(id, feature.Location.Url, feature.Location.Website, feature.Location.Webpage, feature.Team.Id, feature.Team.TeamMembers, feature.Team.TeamName, feature.IsBroken, feature.Name);
                if (!existing)
                {
                    return this.NotFound();
                }
                else
                {
                    return this.Ok(feature);
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
                bool isDeleted = FeatureService.DeleteFeature(id);
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