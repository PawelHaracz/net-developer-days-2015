using pltkw3msCustomer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace pltkw3msCustomer.Controllers
{
    /// <summary>
    /// Manage customer
    /// </summary>
    public class CustomerController : ApiController
    {
        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns></returns>
        // GET api/values
        public IEnumerable<Customer> Get()
        {
            return new Customer[] { new Customer(), new Customer(), new Customer() } ;
        }

        /// <summary>
        /// Get page
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPage")]
        public IEnumerable<Customer> GetPage(int start)
        {
            return new Customer[] { new Customer(), new Customer(), new Customer() };
        }
        /// <summary>
        /// Find customer with
        /// </summary>
        /// <param name="id">ID Customer</param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet]
        public Customer Get(int id)
        {
            return new Customer() { Id = id };
        }

        /// <summary>
        /// Find Customer with similar addresses
        /// </summary>
        /// <param name="address">entered address</param>
        /// <param name="similarFactor">0-1:similarity</param>
        /// <returns></returns>
        [HttpGet]
        [Route("FindCustomerWithSimilarAddresses")]
        IEnumerable<Customer> FindCustomerWithSimilarAddresses(string address, double similarFactor)
        {
            Address normalizedAddress = new Address(); //Call another microservices responsible for normalizing address
            var resp = new Customer[] { new Customer(), new Customer(), new Customer() };
            resp[0].Address = normalizedAddress;
            resp[1].Address = normalizedAddress;
            resp[2].Address = normalizedAddress;
            return resp;
        }
        /// <summary>
        /// Add a new customer
        /// </summary>
        /// <param name="value"></param>
        // POST api/values
        public void Post([FromBody]Customer value)
        {
        }

        /// <summary>
        /// Import customers
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        [Route("AddManyCustomers")]
        // POST api/values
        public void AddManyCustomers([FromBody]Customer[] value)
        {
        }
        /// <summary>
        /// Update customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Delete customer
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
