using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Web_API.Models;

namespace Web_API.Repository
{
    public class AccountRepository : IAccountRepository
    {
        RegisterDbEntities _registerDBContext = null;
        public Customer VerifyLogin(string userName, string password)
        {
            
            Customer customer = null;
            try
            {
                var checkValidUser = _registerDBContext.Customers.Where(m => m.Username == userName &&
            m.Password == password).FirstOrDefault();
                if (checkValidUser != null)
                {
                    customer = checkValidUser;
                }

                else
                {
                    customer = null;
                }
            }
            catch (Exception ex)
            {
            }
            return customer;
        }

        public AccountRepository(RegisterDbEntities registerDBEntities)
        {
            this._registerDBContext = registerDBEntities;
        }
    }
}