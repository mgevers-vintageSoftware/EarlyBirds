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
    [RoutePrefix("customers")]
    public class CustomerController : ApiController
    {
        [Route]
        public IHttpActionResult Get()
        {
            try
            {
                List<Dto.Customer> customers = CustomerService.GetAllCustomers();

                if (customers == null)
                {
                    return this.NotFound();
                }

                return this.Ok(customers);
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
                Dto.Customer customer = CustomerService.GetCustomer(id);
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

        [Route("{name}")]
        public IHttpActionResult Get(string name)
        {
            try
            {
                Dto.Customer customer = CustomerService.GetCustomer(name);
                if (customer == null)
                {
                    return this.NotFound();
                }
                else
                {
                    return this.Ok(customer);
                }
            }
            catch (Exception e)
            {
                return this.InternalServerError(e);
            }
        }

        [Route]
        public IHttpActionResult Post(Dto.Customer customer)
        {
            if (customer == null)
            {
                return this.NotFound();
            }
            try
            {
                CustomerService.PostCustomer(customer.Name, customer.Email, customer.PhoneNumber, customer.Message, customer.TwitterHandle, customer.FacebookName, customer.ContactMethod);
                return this.Created(this.Request.RequestUri.AbsolutePath + "/" + customer.Name, customer);
            }
            catch (Exception e)
            {
                return this.InternalServerError(e);
            }
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(int id, Dto.Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    return this.NotFound();
                }
                bool existing = CustomerService.PutCustomer(id, customer.Name, customer.Email, customer.PhoneNumber, customer.Message, customer.TwitterHandle, customer.FacebookName, customer.ContactMethod);
                if (!existing)
                {
                    return this.NotFound();
                }
                else
                {
                    return this.Ok(customer);
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
                bool isDeleted = CustomerService.DeleteCustomer(id);
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
