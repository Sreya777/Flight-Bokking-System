using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Web_API.Models;

namespace Web_API.Repository
{
    public class UserRepository : IDataRepository<Customer>
    {
        private readonly RegisterDbEntities _RegisterDBContext;

        // Constructor Dependency Injection
        public UserRepository(RegisterDbEntities registerDBContext)
        {
            _RegisterDBContext = registerDBContext;
        }

        public void Add(Customer newUser)
        {
            _RegisterDBContext.Customers.Add(newUser);
            _RegisterDBContext.SaveChanges();
        }

        public void Delete(int entity)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer dbEntity)
        {
            throw new NotImplementedException();
        }

    }
}