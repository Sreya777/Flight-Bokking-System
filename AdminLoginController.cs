using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API.Models;
using Web_API.Repository;

namespace Web_API.Controllers
{
    [RoutePrefix("api/Account")]

    public class AdminLoginController : ApiController
   
    {
        private IAdminLoginRepository _accountRepository;
        public AdminLoginController()
        {
            this._accountRepository = new AdminLoginRepository(new RegisterDbEntities());
        }

        [HttpPost]
        [Route("Login")]
        public IHttpActionResult VerifyLogin(Login objlogin)
        {
            Admin admin = null;
            try
            {
                admin = _accountRepository.VerifyAdminLogin(objlogin.userName, objlogin.password);

                if (admin != null)
                {
                    //return NotFound();
                    return Ok(admin);

                }

            }
            catch (Exception ex)
            {

            }

            //return Ok(customer);
            return NotFound();

        }
    }

}

    

