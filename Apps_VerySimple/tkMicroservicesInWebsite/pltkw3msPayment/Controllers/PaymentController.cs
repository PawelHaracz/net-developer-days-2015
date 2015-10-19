using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace pltkw3msPayment.Controllers
{
    public class PaymentController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "payment-value1", "payment-value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "payment-value" + id.ToString();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }


    }
    public class PaymentStatusController : ApiController
    {
        [HttpGet]
        public string GetPaymentStatus(string orderId)
        {
            return "PAID";
        }
    }
}
