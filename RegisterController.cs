using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.UI.WebControls;
using Web_API.Models;
using Web_API.Repository;

namespace Web_API.Controllers
{

    public class RegisterController : ApiController
    {
        private IDataRepository<Customer> _dataRepository;

        public RegisterController()
        {
            this._dataRepository = new UserRepository(new RegisterDbEntities());
        }

        [HttpPost]
        
        public IHttpActionResult CreateUser([FromBody] Customer userObj)
        {
            try
            {
                RegisterDbEntities nd = new RegisterDbEntities();

                if (nd.Customers.Any(model => model.MobileNumber == userObj.MobileNumber))
                {
                    return new System.Web.Http.Results.ResponseMessageResult(
                    Request.CreateErrorResponse((HttpStatusCode)422, new HttpError("Something goes wrong")));
                }

                if (nd.Customers.Any(model => model.EmailID == userObj.EmailID))
                {
                    return new System.Web.Http.Results.ResponseMessageResult(
                    Request.CreateErrorResponse((HttpStatusCode)423, new HttpError("Something goes wrong")));
                }

                if (nd.Customers.Any(model => model.Username == userObj.Username))
                {
                    return new System.Web.Http.Results.ResponseMessageResult(
                    Request.CreateErrorResponse((HttpStatusCode)424, new HttpError("Something goes wrong")));
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    _dataRepository.Add(userObj);
                    return Ok();

                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}


 

        