using PBDeskDemos.SimpleSPA.DAL;
using PBDeskDemos.SimpleSPA.DAL.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace PBDeskDemos.SimpleSPA.ApiControllers
{
    public class CustomersController  : BaseApiController
    {


        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = null;
            try
            {
                var allKeys = Repo.Customers.GetAll<Customer>().ToList<Customer>();
                response = Request.CreateResponse(HttpStatusCode.OK, allKeys);
            }
            catch (Exception ex)
            {
                Log("Error in CustomersController.Get", ex);
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return response;
        }

        public HttpResponseMessage Post([FromBody]Customer newCustomer)
        {
            HttpResponseMessage response = null;
            if (newCustomer != null)
            {
                try
                {
                    var newlyCreatedCustomer = Repo.Customers.Insert<Customer>(newCustomer);
                    response = Request.CreateResponse(HttpStatusCode.Created, newlyCreatedCustomer);
                }
                catch (Exception ex)
                {
                    Log("Error in CustomersController.Post", ex);
                    response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }
            }
            else
            {
                Log("Null argument in call to CustomersController.Post");
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return response;
        }

        public HttpResponseMessage Put(int id, Customer customer)
        {
            HttpResponseMessage response = null;
            if (id > 0 && customer != null)
            {
                Customer l = null;
                try
                {
                    l = Repo.Customers.Find<Customer>(id);
                }
                catch (Exception ex)
                {
                    Log("Error in CustomersController.Put() While making database call(Find<Customer>).", ex);
                    response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                    return response;
                }
                if (l == null || id != customer.Id)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound);
                }
                try
                {
                    Repo.Customers.Update<Customer>(customer);
                    response = Request.CreateResponse(HttpStatusCode.OK, customer);
                }
                catch (Exception ex)
                {
                    Log("Error in CustomersController.Put() While making database call(Update<Customer>).", ex);
                    response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }


            }
            else
            {
                Log("Null argument in call to CustomersController.Post");
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return response;
        }

        public HttpResponseMessage Delete(int id)
        {
            if (id > 0)
            {
                Customer s = null;
                try
                {
                    s = Repo.Customers.Find<Customer>(id);
                }
                catch (Exception ex)
                {
                    Log("Error in CustomersController.Delete() While making database call(Find<Customer>).", ex);
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }
                if (s == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                try
                {
                    Repo.Customers.Delete<Customer>(s);
                    return Request.CreateResponse(HttpStatusCode.OK, s);
                }
                catch (Exception ex)
                {
                    Log("Error in CustomersController.Delete() While making database call(Delete<Customer>).", ex);
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                }


            }
            else
            {
                Log("Null argument in call to CustomersController.Delete");
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
