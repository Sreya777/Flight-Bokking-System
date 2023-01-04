using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_API.Models;

namespace Web_API.Repository
{
    public class AdminLoginRepository : IAdminLoginRepository
    {
        RegisterDbEntities _registerDBContext = null;
        public Admin VerifyLogin(string userName, string password)
        {

            Admin admin = null;
            try
            {
                var checkValidUser = _registerDBContext.Customers.Where(m => m.Username == userName &&
            m.Password == password).FirstOrDefault();
                if (checkValidUser != null)
                {
                   admin = checkValidUser;
                }

                else
                {
                    admin = null;
                }
            }
            catch (Exception ex)
            {
            }
            return admin;
        }

        public Admin VerifyAdminLogin(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public AdminLoginRepository(RegisterDbEntities registerDBEntities)
        {
            this._registerDBContext = registerDBEntities;
        }
    }
}
    
