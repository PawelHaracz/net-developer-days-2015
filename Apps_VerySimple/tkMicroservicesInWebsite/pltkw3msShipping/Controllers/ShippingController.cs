using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace pltkw3msShipping.Controllers
{
    public class ShippingController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            string msg = Environment.GetEnvironmentVariable("COMPUTERNAME");
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            //Playing with 
            double result = 0;
            for (int i = 0; i < id; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    for (int k = 0; k < 100; k++)
                    {
                        for (int l = 0; l < 100; l++)
                        {
                            result += Math.Sin(i * ((j + k + l) / 10000.0));
                        }

                    }

                }
            }
            sw.Stop();
            return "Get: " + sw.ElapsedMilliseconds + " ms, wynik: " + result;
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
}
